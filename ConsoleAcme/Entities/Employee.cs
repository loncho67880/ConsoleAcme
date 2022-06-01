using System.ComponentModel.DataAnnotations;

namespace ConsoleAcme.Entities
{
    public class Employee
    {
        [Required]
        [Key]
        public string Name { get; set; }
    }
}
