namespace TASK_8_11.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Email { get; set; }
        public int Phone  { get; set; }

        public string  Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
