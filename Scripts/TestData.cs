using DYA.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA.Scripts
{
    class TestData
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
    }
}
