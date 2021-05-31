using Dev_Back.Api.Data;
using Dev_Back.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Back.Api.Models
{
    public class StudentReporitory
    {
        private readonly DataContext _context;
        public StudentReporitory(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<bool> CreateAsync(Student value)
        {
            await _context.Students.AddAsync(value);
            return await SaveAsycn();
        }
        public async Task<bool> UpdateAsync(Student value)
        {
            _context.Students.Update(value);
            return await SaveAsycn();
        }
        public async Task<bool> DeleteAsync(Student value)
        {
            _context.Students.Remove(value);
            return await SaveAsycn();
        }

        public async Task<int> GetTotalStudentsAsync()
        {
            List<Student> students = await GetAsync();
            return students.Count;
        }

        public async Task<StudentDao> GetAverageAsync(int id)
        {
            Student student = await GetAsync(id);
            if (student != null)
            {
                double total = student.Grade1 + student.Grade2 + student.Grade3;
                
                return new StudentDao
                {
                    Id = id,
                    Average = total /  3,
                    Name = student.Name
                };
            }
            return null;
        }

        public async Task<List<StudentDao>> GetAverageAsync()
        {
            var students = await GetAsync();

            if (students.Count > 0)
            {
                var studentsAverage = new List<StudentDao>();
                foreach (var student in students)
                {
                    double total = student.Grade1 + student.Grade2 + student.Grade3;
                    studentsAverage.Add(new StudentDao
                    {
                        Id = student.Id,
                        Average = total / 3,
                        Name = student.Name
                    });
                }
                return studentsAverage;
            }
            return null;
        }

        public async Task<double> GetTotalAverageAsync()
        {
            var students = await GetAsync();
            if (students.Count > 0)
            {
                double total = 0;
                var totalStudents = students.Count;
                foreach (var student in students)
                {
                    total += student.Grade1 + student.Grade2 + student.Grade3;
                }

                return total / (totalStudents * 3);
            }
            return 0;
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(e => e.Id == id);
        }



        public async Task<bool> SaveAsycn()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
