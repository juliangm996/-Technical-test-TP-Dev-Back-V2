using Dev_Back.Api.Controllers;
using Dev_Back.Api.Data;
using Dev_Back.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev_Back.Test.UnitTesting
{
    [TestClass]
    public class ClassroomsControllerTest : BaseTest
    {


        [TestMethod]
        public async Task GetClassrooms()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            context.Classrooms.Add(new Classroom { Name = "Classrrom 2" });
            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);

            ClassroomsController controller = new ClassroomsController(context2);
            ActionResult<List<Classroom>> response = await controller.GetClassrooms();


            List<Classroom> classrooms = response.Value;
            Assert.AreEqual(2, classrooms.Count);
        }


        [TestMethod]
        public async Task GetClassroomNotExist()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            ClassroomsController controller = new ClassroomsController(context);
            ActionResult<Classroom> response = await controller.GetClassroom(1);

            StatusCodeResult result = response.Result as StatusCodeResult;
            Assert.AreEqual(404, result.StatusCode);

        }

        [TestMethod]
        public async Task GetClassroomExist()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            context.Classrooms.Add(new Classroom { Name = "Classrrom 2" });
            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);

            ClassroomsController controller = new ClassroomsController(context2);

            int id = 1;
            ActionResult<Classroom> response = await controller.GetClassroom(id);
            var result = response.Value;
            Assert.AreEqual(id, result.Id);

        }

        [TestMethod]
        public async Task GetTotalStudentsByClassroom()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);
            context.Classrooms.Add(new Classroom { Name = "Classrrom 1" });
            await context.Students.AddAsync(new Student { Name = "Marcela", Grade1 = 1.5, Grade2 = 3, Grade3 = 5, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Gabriela", Grade1 = 2.1, Grade2 = 1.5, Grade3 = 3, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Jorge", Grade1 = 4.8, Grade2 = 2, Grade3 = 2.1, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Julian", Grade1 = 3.6, Grade2 = 4.3, Grade3 = 1.8, ClassroomId = 1 });
            await context.Students.AddAsync(new Student { Name = "Ana", Grade1 = 4.4, Grade2 = 5, Grade3 = 3.4, ClassroomId = 1 });

            await context.SaveChangesAsync();

            DataContext context2 = BuildContext(dbName);

            ClassroomsController controller = new ClassroomsController(context2);

            var id = 1;
            ActionResult<int> response = await controller.GetTotalStudentsByClassroom(id);
            var result = response.Value;
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public async Task GetAverageClassroom()
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

            ClassroomsController controller = new ClassroomsController(context2);

            var id = 1;
            ActionResult<ClassroomDao> response = await controller.GetAverageClassroom(id);
            var result = response.Value;
            Assert.AreEqual(5, result.TotalStudents);

            Assert.AreEqual(2.87, Math.Round(result.ClassroomAverage, 2));

            Assert.AreEqual("Classrrom 1", result.Name);
        }


        [TestMethod]
        public async Task GetAverage()
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

            ClassroomsController controller = new ClassroomsController(context2);

            var id = 1;
            ActionResult<ClassroomAverage> response = await controller.GetAverage(id);
            var result = response.Value;
            Assert.AreEqual(5, result.TotalStudents);

            Assert.AreEqual(2.87, Math.Round(result.Average,2));

            Assert.AreEqual("Classrrom 1", result.Name);



        }

        [TestMethod]
        public async Task PutClassroom()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            context.Classrooms.Add(new Classroom { Name = "Classroom 1" });
            await context.SaveChangesAsync();

            var context2 = BuildContext(dbName);

            ClassroomsController controller = new ClassroomsController(context2);

            var classroom = new Classroom { Id = 1, Name = "test" };

            var id = 1;
           await controller.PutClassroom(id,classroom);
           
            var exist = await context2.Classrooms.AnyAsync(x=>x.Name == "test");
            Assert.IsTrue(exist);
        }


        [TestMethod]
        public async Task PostClassroom()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            var classroom = new Classroom
            {
                Name = "Classroom 1"
            };

            ClassroomsController controller = new ClassroomsController(context);
            var response = await controller.PostClassroom(classroom) as StatusCodeResult;

            var context2 = BuildContext(dbName);
            var totalData = await context2.Classrooms.CountAsync();
            Assert.AreEqual(1, totalData);
        }

        [TestMethod]
        public async Task DeleteClassroom()
        {
            string dbName = Guid.NewGuid().ToString();
            DataContext context = BuildContext(dbName);

            context.Classrooms.Add(new Classroom { Name = "Classroom 1" });
            await context.SaveChangesAsync();

            var context2 = BuildContext(dbName);

            ClassroomsController controller = new ClassroomsController(context2);

            var id = 1;
           await controller.DeleteClassroom(id);

            var exist = !await context2.Classrooms.AnyAsync();
             Assert.IsTrue(exist);
        }

      


    }
}
