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
        public string ClassName { get; set; }

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

        public float CurrentPoints
        {
            get
            {
                float curPoints = new float();

                for (int i = 0; i < Assignments.Count; i++)
                {
                    curPoints += Assignments[i].PointsReached;
                }

                return curPoints;
            }
        }
        public float MaxPoints
        {
            get
            {
                float maxPoints = new float();

                for (int i = 0; i < Assignments.Count; i++)
                {
                    maxPoints += Assignments[i].PointsMax;
                }

                return maxPoints;
            }
        }
        public float PercentagePoints
        {
            get
            {
                if (MaxPoints == 0)
                    return 0;

                return CurrentPoints / MaxPoints;
            }
        }
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
                if (PointsMax == 0)
                    return 0;

                return PointsReached / PointsMax;
            }
        }

    }
}
