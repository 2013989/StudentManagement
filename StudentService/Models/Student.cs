using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentService.Models
{
    public class Student
    {
        [Key]
        public int RollNumber { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public int Hindi { get; set; }

        public int English { get; set; }

        public int Maths { get; set; }
    }
}
