using Dev_Back.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Back.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random = new Random();
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckClassroomAsync();
            await CheckStudentAsync();
        }

        private async Task CheckClassroomAsync()
        {
            if (!_context.Classrooms.Any())
            {
                var classrooms = CreateClassrooms();
                await _context.Classrooms.AddRangeAsync(classrooms);
                await _context.SaveChangesAsync();
            }
        }


        private async Task CheckStudentAsync()
        {
            if (!_context.Students.Any())
            {
                await _context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1.5, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
                await _context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2.1, Grade2 = 1.5, Grade3 = 3, ClassroomId = 1 });
                await _context.Students.AddAsync(new Student { Name = "Jorge", Grade1 = 4.8, Grade2 = 2, Grade3 = 2.1, ClassroomId = 1 });
                await _context.Students.AddAsync(new Student { Name = "Julian", Grade1 = 3.6, Grade2 = 4.3, Grade3 = 1.8, ClassroomId = 1 });
                await _context.Students.AddAsync(new Student { Name = "Ana", Grade1 = 4.4, Grade2 = 5, Grade3 = 3.4, ClassroomId = 1 });
                await _context.SaveChangesAsync();
            }
        }

        private List<Classroom> CreateClassrooms()
        {
            int cant = 10;
            List<int> numbers = new List<int>();
            List<Classroom> classrooms = new List<Classroom>();
            do
            {
                int classroomNumber = _random.Next(101, 150);
                if (!numbers.Contains(classroomNumber)) {

                    classrooms.Add(new Classroom
                    {
                        Name = $"Classroom  {classroomNumber}",
                        
                    });
                    numbers.Add(classroomNumber);
                }

            } while ( cant >= classrooms.Count);

            return classrooms;
        }
    }
}
