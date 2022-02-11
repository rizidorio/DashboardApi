namespace Dashboard.Domain.Entity
{
    public class ItemsOrder
    {
        public int Id { get; set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; set; }
        public int Quantity { get; private set; }
        public decimal TotalValue { get; private set; }

        public ItemsOrder(int orderId, int productId, int quantity, decimal totalValue)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            TotalValue = totalValue;
        }

        public void Update(int orderId, int productId, int quantity, decimal totalValue)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            TotalValue = totalValue;
        }
    }
}
