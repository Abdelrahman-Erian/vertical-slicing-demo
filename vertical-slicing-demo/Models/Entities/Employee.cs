using System.ComponentModel.DataAnnotations.Schema;

namespace vertical_slicing_demo.Models.Entities
{
    public class Employee : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey(nameof(Department))]
        public Guid? DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
