using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Back.Api.Entities
{
    public class ClassroomDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalStudents { get; set; }
        public double ClassroomAverage { get; set; }
    }
}
