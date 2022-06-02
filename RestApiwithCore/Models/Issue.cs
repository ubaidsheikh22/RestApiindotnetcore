using System.ComponentModel.DataAnnotations;

namespace RestApiwithCore.Models
{
    public class Issue
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desccription { get; set; }

        public Priority Priority { get; set; }

        public Issuetype Issuetype { get; set; }

    }
    public enum Priority 
    {
        low,medium,high
    }
    public  enum Issuetype 
    {
     feature,bug,documentation
    }
}
