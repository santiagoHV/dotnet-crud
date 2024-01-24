namespace api_crud_net.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required List<Order> Orders { get; set; }
    }
}
