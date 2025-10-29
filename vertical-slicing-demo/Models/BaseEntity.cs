namespace vertical_slicing_demo.Models
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
