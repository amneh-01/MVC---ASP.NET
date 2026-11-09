namespace TASK_8_11.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
       
        public virtual ICollection<Category> CategoryId { get; set; }
        public virtual ICollection<Supplier> SupplierId { get; set; }

    }
}
