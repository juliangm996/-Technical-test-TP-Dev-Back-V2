using Dev_Back.Api.Controllers;
using Dev_Back.Api.Data;
using Dev_Back.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Back.Test.UnitTesting
{
    [TestClass]
    public class StudentsControllerTest:BaseTest
    {

        [TestMethod]
        public async Task GetStudents()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1.5, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2.1, Grade2 = 1.5, Grade3 = 3, ClassroomId = 1 });
            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);

            StudentsController controller = new StudentsController(context2);
            ActionResult<List<Student>> response = await controller.GetStudents();
            List<Student> classrooms = response.Value;
            Assert.AreEqual(2, classrooms.Count);
        }


        [TestMethod]
        public async Task GetStudentNotExist()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            StudentsController controller = new StudentsController(context);
            ActionResult<Student> response = await controller.GetStudent(1);

            StatusCodeResult result = response.Result as StatusCodeResult;
            Assert.AreEqual(404, result.StatusCode);

        }

        [TestMethod]
        public async Task GetStudent()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1.5, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2.1, Grade2 = 1.5, Grade3 = 3, ClassroomId = 1 });
            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);

            StudentsController controller = new StudentsController(context2);

            int id = 1;
            ActionResult<Student> response = await controller.GetStudent(id);
            var result = response.Value;
            Assert.AreEqual(id, result.Id);

        }





        [TestMethod]
        public async Task GetTotalStudents()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2, Grade2 = 1, Grade3 = 3, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Jorge", Grade1 = 4, Grade2 = 2, Grade3 = 2, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Julian", Grade1 = 3, Grade2 = 4, Grade3 = 1, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Ana", Grade1 = 4, Grade2 = 5, Grade3 = 3, ClassroomId = 1 });

            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);
            StudentsController controller = new StudentsController(context2);
           
            ActionResult<int> response = await controller.GetTotalStudents();
            var result = response.Value;
            Assert.AreEqual(5, result);

           
        }

        [TestMethod]
        public async Task GetAverageAsyncByStudent()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });

            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);
            StudentsController controller = new StudentsController(context2);

            var id = 1;
            ActionResult<StudentDao> response = await controller.GetAverageAsyncByStudent(id);
            var result = response.Value;
            Assert.AreEqual(3, result.Average);
        }

        [TestMethod]
        public async Task GetAverageAsync()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2, Grade2 = 1, Grade3 = 3, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Jorge", Grade1 = 4, Grade2 = 2, Grade3 = 2, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Julian", Grade1 = 3, Grade2 = 4, Grade3 = 1, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Ana", Grade1 = 4, Grade2 = 5, Grade3 = 3, ClassroomId = 1 });

            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);
            StudentsController controller = new StudentsController(context2);

            ActionResult<List<StudentDao>> response = await controller.GetAverageAsync();
            var result = response.Value;
            Assert.AreEqual(5, result.Count());
        }



        [TestMethod]
        public async Task GetTotalAverageAsync()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2, Grade2 = 1, Grade3 = 3, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Jorge", Grade1 = 4, Grade2 = 2, Grade3 = 2, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Julian", Grade1 = 3, Grade2 = 4, Grade3 = 1, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Ana", Grade1 = 4, Grade2 = 5, Grade3 = 3, ClassroomId = 1 });

            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);
            StudentsController controller = new StudentsController(context2);

            ActionResult<double> response = await controller.GetTotalAverageAsync();
            var result = response.Value;
            Assert.AreEqual(2.87, Math.Round(result, 2));
        }





        [TestMethod]
        public async Task PutStudent()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1.5, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.SaveChangesAsync();

            var context2 = BuildContext(dbName);

            StudentsController controller = new StudentsController(context2);

            var student = new Student {Id=1, Name = "test", Grade1 = 1.5, Grade2 = 3, Grade3 = 5, ClassroomId = 1 };

            var id = 1;
            await controller.PutStudent(id, student);

            var exist = await context2.Students.AnyAsync(x => x.Name == "test");
            Assert.IsTrue(exist);
        }


        [TestMethod]
        public async Task PostStudent()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            var student = new Student { Name = "Gabriela", Grade1 = 2.1, Grade2 = 1.5, Grade3 = 3, ClassroomId = 1 };

            StudentsController controller = new StudentsController(context);
             await controller.PostStudent(student);

            var context2 = BuildContext(dbName);
            var totalData = await context2.Students.CountAsync();
            Assert.AreEqual(1, totalData);
        }

        [TestMethod]
        public async Task DeleteStudent()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2.1, Grade2 = 1.5, Grade3 = 3, ClassroomId = 1 });
            await context.SaveChangesAsync();

            var context2 = BuildContext(dbName);

            StudentsController controller = new StudentsController(context2);

            var id = 1;
            await controller.DeleteStudent(id);

            var exist = !await context2.Classrooms.AnyAsync();
            Assert.IsTrue(exist);
        }
    }
}
