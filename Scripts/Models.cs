using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA.Scripts.Models
{
    public class CourseModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Weekcounts { get; set; }

        public DateTime FirstDue { get; set; }

        public int LowerLimit { get; set; }

        public List<AssignmentModel> Assignments { get; set; } = new List<AssignmentModel>();

        public AssignmentModel W1
        {
            get
            {
                if (Assignments.Count >= 1)
                    return Assignments[0];
                return null;
            }

            set
            {
                Assignments[0] = W1;
            }
        }

        public AssignmentModel W2
        {
            get
            {
                if (Assignments.Count >= 2)
                    return Assignments[1];
                return null;
            }

            set
            {
                Assignments[1] = W2;
            }
        }

        public int CurrentPoints { get; set; }
    }

    public class AssignmentModel
    {
        public int Week { get; set; }
        public DateTime DueTime { get; set; }
        public bool Submitted { get; set; }
        public float PointsMax { get; set; }
        public float PointsReached { get; set; }

        public float PointsPercentage
        {
            get
            {
                return PointsReached / PointsMax;
            }
        }

    }
}
