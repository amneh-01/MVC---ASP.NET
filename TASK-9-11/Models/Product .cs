namespace TASK_8_11.Models
{
    public class Product
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
  
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public int SupplierId { get; set; }
        public Supplier supplier { get; set; }


    }
}
