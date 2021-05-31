using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Back.Api.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
