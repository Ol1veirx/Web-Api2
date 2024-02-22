﻿namespace WebApi2.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int OrderId { get; set; }
    }
}
