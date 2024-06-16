using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace ProjectWeb.Models
{
    public class student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int phone { get; set; }
        public string Address { get; set; }
        
    }
}
