using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Repositorypattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
   
        static private List<Student> student = new List<Student> {

            new Student {
        Id = 1,
       firstname = "archana",
        middlename = "h",
       lastname = "patel",
       place= "valsad" ,
       JoiningDate = new DateTime(2025, 5, 27),
    },
         new Student{
          Id = 2,
       firstname = "archana",
        middlename = "h",
       lastname = "patel",
       place= "valsad" ,
       JoiningDate = new DateTime(2025, 5, 27),
          },

        };
        //// GET: api/student
        //[HttpGet]
        //public ActionResult<List<StudentDto>> GetStudents()
        //{
        //    var result = student.Select(s => new StudentDto
        //    {
        //        firstname = s.firstname,
        //        middlename = s.middlename,
        //        lastname = s.lastname
        //    }).ToList();

        //    return Ok(result);
        //}
        //// POST: api/student
        //[HttpPost]
        //public IActionResult AddStudent(StudentDto dto)
        //{
        //    var newStudent = new Student
        //    {
        //        Id = student.Max(s => s.Id) + 1,
        //        firstname = dto.firstname,
        //        middlename = dto.middlename,
        //        lastname = dto.lastname,
        //        place = "valsad", // optional: you can add this to DTO if needed
        //        JoiningDate = DateTime.Now
        //    };

        //    student.Add(newStudent);
        //    return Ok("Student added successfully.");
        //}

        private readonly IMapper _mapper;

        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> GetStudents()
        {
            var dtos = _mapper.Map<List<StudentDto>>(student);
            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDto dto)
        {
            var newStudent = _mapper.Map<Student>(dto);
            newStudent.Id = student.Max(s => s.Id) + 1;
            newStudent.place = "valsad";
            newStudent.JoiningDate = DateTime.Now;

            student.Add(newStudent);
            return Ok("Student added.");
        }

    }
}
