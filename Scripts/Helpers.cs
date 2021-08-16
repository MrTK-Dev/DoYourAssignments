using DYA.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA.Scripts
{
    public class Helpers
    {
        static public AssignmentModel GetLatestAssignment(CourseModel courseModel)
        {
            List<AssignmentModel> assignmentModels = new List<AssignmentModel>(courseModel.Assignments);

            for (int i = 0; i < assignmentModels.Count; i++)
                if (!assignmentModels[i].Submitted)
                    return assignmentModels[i];

            return null;
        }

        public enum GoalKind
        {
            none,
            Percentage,
            fiftyfifty
        }

        public enum GoalDiscard
        {
            none,
            First,
            Last
        }

        static public bool HasReachedGoal(CourseModel courseModel)
        {
            switch (courseModel.GoalKind)
            {
                case GoalKind.none:
                    return false;

                case GoalKind.Percentage:
                    return courseModel.PercentagePoints >= courseModel.GoalPercentage;

                case GoalKind.fiftyfifty:
                    List<AssignmentModel> FirstHalf = new List<AssignmentModel>();
                    List<AssignmentModel> SecondHalf = new List<AssignmentModel>();

                    //checks if the week count is even
                    if (courseModel.Weekcount % 2 == 0)
                        for (int i = 0; i < courseModel.Weekcount; i++)
                        {
                            if (i < courseModel.Weekcount / 2)
                                FirstHalf.Add(courseModel.Assignments[i]);
                            else
                                SecondHalf.Add(courseModel.Assignments[i]);
                        }
                    else
                    {
                        int breakPoint = new int();

                        switch (courseModel.GoalDiscard)
                        {
                            case GoalDiscard.none:
                                break;

                            case GoalDiscard.First:
                                breakPoint = (int)Math.Floor((float)courseModel.Weekcount / 2);
                                break;

                            case GoalDiscard.Last:
                                breakPoint = (int)Math.Ceiling((float)courseModel.Weekcount / 2);
                                break;

                            default:
                                break;
                        }

                        for (int i = 0; i < courseModel.Weekcount; i++)
                        {
                            if (i < breakPoint)
                                FirstHalf.Add(courseModel.Assignments[i]);
                            else
                                SecondHalf.Add(courseModel.Assignments[i]);
                        }
                    }

                    //check if both halfes reached enough points
                    return GetPercentageOfList(FirstHalf) > courseModel.GoalPercentage & GetPercentageOfList(SecondHalf) > courseModel.GoalPercentage;

                default:
                    return false;
            }
        }

        static float GetPercentageOfList(List<AssignmentModel> assignmentModels)
        {
            float reachedPoints = new float();
            float maxPoints = new float();

            for (int i = 0; i < assignmentModels.Count; i++)
            {
                reachedPoints += assignmentModels[i].PointsReached;

                maxPoints += assignmentModels[i].PointsMax;
            }

            return reachedPoints / maxPoints;
        }
    }
}
