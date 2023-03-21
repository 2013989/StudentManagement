using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentService.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studentList = await _context.Student.ToListAsync();
            if (studentList == null)
                return NotFound();
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _context.Student.FirstOrDefaultAsync(m => m.RollNumber == id);
            if (student == null)
                return NotFound();
            return Ok(student);

        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Student studentData)

        {
            Student stu = new Student();
            stu.RollNumber = studentData.RollNumber;
            stu.Name = studentData.Name;
            stu.DateOfBirth= studentData.DateOfBirth;
            stu.Hindi= studentData.Hindi;
            stu.English= studentData.English;
            stu.Maths=studentData.Maths;
            _context.Student.Add(stu);
             await _context.SaveChangesAsync();
            return Ok();
            

        }
    }
}
