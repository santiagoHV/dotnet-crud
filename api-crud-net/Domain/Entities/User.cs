﻿namespace api_crud_net.Domain.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set;}
        public List<Order>? Orders { get; set; }
    }
}
