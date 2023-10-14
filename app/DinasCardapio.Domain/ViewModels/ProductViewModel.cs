using DinasCardapio.Domain.Entities;
using DinasCardapio.Domain.Enums;

namespace DinasCardapio.Domain.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name.Title;
            Price = product.Price.Value;
            ImageUrl = product.UrlImage.Url;
            Type = product.Type;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public EProductType Type { get; private set; }
    }
}
