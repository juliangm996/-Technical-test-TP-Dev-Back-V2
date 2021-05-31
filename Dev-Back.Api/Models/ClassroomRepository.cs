using Dev_Back.Api.Data;
using Dev_Back.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Back.Api.Models
{
    public class ClassroomRepository
    {
        private readonly DataContext _context;
        public ClassroomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Classroom> GetAsync(int id)
        {
            return await _context.Classrooms.FindAsync(id);
        }

        public async Task<List<Classroom>> GetAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }

        public async Task<bool> CreateAsync(Classroom value)
        {
            await _context.Classrooms.AddAsync(value);
            return await SaveAsycn();
        }
        public async Task<bool> UpdateAsync(Classroom value)
        {
            _context.Classrooms.Update(value);
            return await SaveAsycn();
        }
        public async Task<bool> DeleteAsync(Classroom value)
        {
            _context.Classrooms.Remove(value);
            return await SaveAsycn();
        }

        public async Task<int> GetTotalStudentsByClassroomAsync(int id)
        {
            List<Student> students = await _context.Students.AsNoTracking().Where(x => x.ClassroomId == id).ToListAsync();
            return students.Count;
        }

        public async Task<ClassroomDao> GetAverageClassroomAsync(int id)
        {
            Classroom classroom = await GetAsync(id);
            List<Student> students = await _context.Students.AsNoTracking().Where(x => x.ClassroomId == id).ToListAsync();

            double total = 0;
            int totalStudents = students.Count;
            foreach (Student student in students)
            {
                total += student.Grade1 + student.Grade2 + student.Grade3;
            }

            return new ClassroomDao
            {
                Id = id,
                ClassroomAverage = totalStudents > 0 ? total / (totalStudents * 3) : 0,
                Name = classroom.Name,
                TotalStudents = totalStudents
            };

        }

        public async Task<ClassroomAverage> GetAverageAsync(int id)
        {
            StudentReporitory studentReporitory = new StudentReporitory(_context);
            Classroom classroom = await GetAsync(id);
            List<Student> students = await _context.Students.AsNoTracking().Where(x => x.ClassroomId == id).ToListAsync();
            var studentsAverage = await studentReporitory.GetAverageAsync();
            double total = 0;
            int totalStudents = students.Count;
            foreach (Student student in students)
            {
                total += student.Grade1 + student.Grade2 + student.Grade3;
            }

            return new ClassroomAverage
            {
                Id = id,
                Average = totalStudents > 0 ? total / (totalStudents * 3) : 0,
                Name = classroom.Name,
                Students = studentsAverage,
                TotalStudents = totalStudents
            };

        }

        public async Task<bool> ClassroomExists(int id)
        {
            return await _context.Classrooms.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAsycn()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
