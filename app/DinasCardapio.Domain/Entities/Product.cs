using DinasCardapio.Domain.Enums;
using DinasCardapio.Domain.ValueObjects;
using DinasCardapio.Shared.Entities;

namespace DinasCardapio.Domain.Entities
{
    public class Product : Entity
    {
        public Product(Name name, Price price, ImageUrl urlImage, EProductType type, string? size)
        {
            Name = name;
            Price = price;
            UrlImage = urlImage;
            Type = type;
            Size = size;

            AddNotifications(Name, Price, UrlImage);
        }

        public Name Name { get; private set; }
        public Price Price { get; private set; }
        public ImageUrl UrlImage { get; private set; }
        public EProductType Type { get; private set; }
        public string? Size { get; private set; }
    }
}
