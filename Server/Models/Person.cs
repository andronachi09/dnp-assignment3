using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Server.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public string HairColor { get; set; }
        [NotNull]
        public string EyeColor { get; set; }
        [NotNull, Range(0, 150)]
        
        public int Age { get; set; }
        public float Weight { get; set; } 
        public int Height { get; set; }
        public string Sex { get; set; }
    }
}