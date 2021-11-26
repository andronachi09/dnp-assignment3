using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Job
    {   
        [Key]
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}