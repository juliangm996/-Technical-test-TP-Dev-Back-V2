using Dev_Back.Api.Data;
using Dev_Back.Api.Entities;
using Dev_Back.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev_Back.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentReporitory _repository;

        public StudentsController(DataContext context)
        {
            _repository = new StudentReporitory(context);
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return await _repository.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            Student student = await _repository.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<int>> GetTotalStudents()
        {
            return await _repository.GetTotalStudentsAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<StudentDao>> GetAverageAsyncByStudent(int id)
        {
            Student student = await _repository.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return await _repository.GetAverageAsync(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<StudentDao>>> GetAverageAsync()
        {

            return await _repository.GetAverageAsync();
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<double>> GetTotalAverageAsync()
        {

            return await _repository.GetTotalAverageAsync();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Model invalid");
            }

            if (!await _repository.StudentExists(id))
            {
                return NotFound("Classroom not find");
            }

            bool response = await _repository.UpdateAsync(student);
            if (response)
            {
                return Ok("Classroom Update");
            }
            return NotFound("Classroom Could not be update");
        }


        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            bool response = await _repository.CreateAsync(student);
            if (response)
            {
                return Ok("Classroom create");
            }
            return NotFound("Classroom Could not be create");
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student student = await _repository.GetAsync(id);
            if (student == null)
            {
                return NotFound("Classroom does not exist ");
            }

            bool response = await _repository.DeleteAsync(student);
            if (response)
            {
                return Ok("Classroom delete");
            }
            return NotFound("Classroom Could not be delete");
        }


    }
}
