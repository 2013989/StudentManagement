using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
    : base(options)
        { }
        public DbSet<Student> Student { get; set; }
    }
}
