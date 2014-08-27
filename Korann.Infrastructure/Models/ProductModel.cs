namespace Korann.Infrastructure.Models
{
    public class ProductModel : IEntityModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}