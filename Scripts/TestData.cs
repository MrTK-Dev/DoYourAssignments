using DYA.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA.Scripts
{
    public class TestData
    {
        CourseModel Course0 = new CourseModel()
        {
            Assignments = new List<AssignmentModel>(),
            ClassName = "Empty Class",
            FirstDue = new DateTime(),
            GoalDiscard = Helpers.GoalDiscard.none,
            GoalKind = Helpers.GoalKind.none,
            GoalPercentage = (float)0,
            ID = 0,
            LowerLimit = 0,
            Name = "Empty Course",
            Weekcount = 0
        };

        CourseModel Course1 = new CourseModel()
        {
            Assignments = new List<AssignmentModel>(),
            ClassName = "Physics",
            FirstDue = DateTime.Now,
            GoalDiscard = Helpers.GoalDiscard.none,
            GoalKind = Helpers.GoalKind.Percentage,
            GoalPercentage = (float)0.5,
            ID = 1,
            LowerLimit = 0,
            Name = "Percentage Course",
            Weekcount = 7
        };

        CourseModel Course2 = new CourseModel()
        {
            Assignments = new List<AssignmentModel>(),
            ClassName = "Physics",
            FirstDue = DateTime.Now,
            GoalDiscard = Helpers.GoalDiscard.none,
            GoalKind = Helpers.GoalKind.LowerLimit,
            GoalPercentage = (float)0,
            ID = 2,
            LowerLimit = 50,
            Name = "LowerLimit Course",
            Weekcount = 10
        };

        CourseModel Course3 = new CourseModel()
        {
            Assignments = new List<AssignmentModel>(),
            ClassName = "Mathematics",
            FirstDue = DateTime.Now,
            GoalDiscard = Helpers.GoalDiscard.First,
            GoalKind = Helpers.GoalKind.fiftyfifty,
            GoalPercentage = (float)0.6,
            ID = 3,
            LowerLimit = 0,
            Name = "fiftyfifty Course",
            Weekcount = 5
        };

        List<AssignmentModel> GetRandomAssignments(CourseModel courseModel)
        {
            List<AssignmentModel> newAssignmentModels = new List<AssignmentModel>();

            for (int i = 0; i < courseModel.Weekcount; i++)
            {
                int maxPoints = new Random().Next(10, 21);

                newAssignmentModels.Add(new AssignmentModel()
                {
                    Week = i + 1,
                    Submitted = true,
                    DueTime = courseModel.FirstDue.AddDays(i * 7),
                    PointsMax = maxPoints,
                    PointsReached = new Random().Next(0, maxPoints + 1)
                });
            }

            return newAssignmentModels;
        }

        public ObservableCollection<CourseModel> GetCourses()
        {
            Course1.Assignments = GetRandomAssignments(Course1);
            Course2.Assignments = GetRandomAssignments(Course2);
            Course3.Assignments = GetRandomAssignments(Course3);

            List<CourseModel> courseModels = new List<CourseModel>
            {
                Course0,
                Course1,
                Course2,
                Course3
            };

            return new ObservableCollection<CourseModel>(courseModels);
        }
    }
}
