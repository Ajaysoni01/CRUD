using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class EmployeeDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Employee Name", TypeName = "varchar(100)")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]

        public string? EmployeeName { get; set; } = null;

        [Required]
        [Column("Employee Email", TypeName = "varchar(100)")]
        public string? Email { get; set; } = null;

        [Required]
        [Column("Employee Company", TypeName = "varchar(100)")]
        public string? Company { get; set; } = null;

        public int EmployeeID { get; set; }


        
        public int EmployeeAge { get; set; }
        
    }
}
