using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA.Scripts.Models
{
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
