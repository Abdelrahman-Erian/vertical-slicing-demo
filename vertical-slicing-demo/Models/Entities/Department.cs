namespace vertical_slicing_demo.Models.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
