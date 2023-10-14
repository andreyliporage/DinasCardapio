using DinasCardapio.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DinasCardapio.Domain.Commands
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public CreateProductCommand(string name, decimal price, string imageUrl, int type, string? size)
        {
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            Type = type;
            Size = size;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Type { get; set; }
        public string? Size { get; set; }

        public void Validate()
        {
            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")
                        .HasMinLen(Name, 4, "Name", "Nome deve ter pelo menos 4 caracteres")
                        .IsNotNull(Price, "Price", "Valor é obrigatório")
                        .IsGreaterThan(Price, 0, "Price", "Valor deve ser maior que zero")
                        .IsNotNullOrEmpty(ImageUrl, "Url", "Url da imagem é obrigatória")
                        .IsUrl(ImageUrl, "Url", "Url inválida")
                        .IsNotNull(Type, "Type", "Tipo deve ser informado")
                );
        }
    }
}
