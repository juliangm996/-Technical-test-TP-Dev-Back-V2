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
    public class ClassroomsController : ControllerBase
    {

        private readonly ClassroomRepository _repository;
        public ClassroomsController(DataContext context)
        {
            _repository = new ClassroomRepository(context);
        }


        [HttpGet]
        public async Task<ActionResult<List<Classroom>>> GetClassrooms()
        {
            return await _repository.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            Classroom classroom = await _repository.GetAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<int>> GetTotalStudentsByClassroom(int id)
        {
            Classroom classroom = await _repository.GetAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return await _repository.GetTotalStudentsByClassroomAsync(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ClassroomDao>> GetAverageClassroom(int id)
        {
            Classroom classroom = await _repository.GetAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }
            return await _repository.GetAverageClassroomAsync(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ClassroomAverage>> GetAverage(int id)
        {
           
            return await _repository.GetAverageAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return BadRequest("Model invalid");
            }

            if (!await _repository.ClassroomExists(id))
            {
                return NotFound("Classroom not find");
            }

            bool response = await _repository.UpdateAsync(classroom);
            if (response)
            {
                return Ok("Classroom Update");
            }
            return NotFound("Classroom Could not be update");
        }


        [HttpPost]
        public async Task<IActionResult> PostClassroom(Classroom classroom)
        {
            bool response = await _repository.CreateAsync(classroom);
            if (response)
            {
                return Ok("Classroom create");
            }
            return NotFound("Classroom Could not be create");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            Classroom classroom = await _repository.GetAsync(id);
            if (classroom == null)
            {
                return NotFound("Classroom does not exist ");
            }

            bool response = await _repository.DeleteAsync(classroom);
            if (response)
            {
                return Ok("Classroom delete");
            }
            return NotFound("Classroom Could not be delete");
        }

    }
}
