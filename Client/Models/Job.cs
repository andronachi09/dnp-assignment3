using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}