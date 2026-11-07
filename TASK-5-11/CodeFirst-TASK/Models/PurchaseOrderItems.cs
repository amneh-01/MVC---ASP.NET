namespace CodeFirst_TASK.Models
{
    public class PurchaseOrderItems
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }


        public decimal UnitPrice { get; set; }

        public PurchaseOrders PurchaseOrder { get; set; }

        public Products Product { get; set; }

    }
}
