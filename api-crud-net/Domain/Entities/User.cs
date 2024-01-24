namespace api_crud_net.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set;}
        public required List<Order> Orders { get; set; }
    }
}
