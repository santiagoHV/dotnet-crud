namespace api_crud_net.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
        public required int UnitPrice { get; set; }
        public required int Subtotal { get; set; }
        public required int Iva { get; set; }
        public required int Total { get; set; }
        public required User User { get; set; }
        public required Product Product { get; set; }


    }
}
