using System.ComponentModel.DataAnnotations;

namespace EFDemo.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A course needs to have a code.")]
        public string Code { get; set; }

        public string Naam { get; set; }

        public Course() { }

        public Course(int id, string code, string naam)
        {
            Id = id;
            Code = code;
            Naam = naam;
        }
    }
}
