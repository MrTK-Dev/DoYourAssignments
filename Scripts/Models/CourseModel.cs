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
    }
}
