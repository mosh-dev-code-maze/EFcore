using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using crud.Models;
using crud.Models.Repository;
using Microsoft.AspNetCore.Mvc;


namespace crud.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IDataRepository<Student> dataRepository;

        /// <summary>
        /// Initializes a new instance of the StudentController class
        /// </summary>
        /// <param name="dataRepository"></param>
        public StudentController(IDataRepository<Student> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        /// <summary>
        /// [Lookup] Returns a list of students 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var students = dataRepository.GetAll();
            return Ok(students);
        }

        /// <summary>
        /// [GetStudent] Returns a student object by id passed in as a parameter. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("Student Not Found. ");
            }
            return Ok(student);
        }

        /// <summary>
        /// [CreateStudent] 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid Payload.");
            }
            dataRepository.Add(student);
            return Created("", student);

        }

        /// <summary>
        /// [UpdateStudent] Updates a student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid Payload");
            }
            var targetStudent = dataRepository.Get(id);
            if (targetStudent == null)
            {
                return NotFound("Student Not Found. ");
            }
            dataRepository.Update(targetStudent, student);
            return Ok(targetStudent);
        }

        /// <summary>
        /// [DeleteStudent] Deletes a student for a given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("Student Not Found. ");
            }
            dataRepository.Delete(student);
            return Ok(student);
        }
    }
}
