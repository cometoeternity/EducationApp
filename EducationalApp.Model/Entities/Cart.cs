using System;

namespace EducationalApp.Model.Entities
{
    public class Cart
    {
    }

    public class CartLine
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
