using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace ProjectWeb.Models
{
    public class StudentBorrow
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public int? StudentId { get; set; }
        public int? BookID { get; set; }
        public string Remark { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateDataTime { get; set; } = DateTime.Now;
        public DateTime? ReterningDataTime { get; set; }
        public string SpendTime { get; set; }



        public virtual student student { get; set; } //include the primary key table object 
        public virtual Book Book { get; set; }
    }
}
