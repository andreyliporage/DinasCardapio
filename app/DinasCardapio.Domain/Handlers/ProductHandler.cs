using DinasCardapio.Domain.Commands;
using DinasCardapio.Domain.Entities;
using DinasCardapio.Domain.Enums;
using DinasCardapio.Domain.Repositories;
using DinasCardapio.Domain.ValueObjects;
using DinasCardapio.Shared.Commands;
using DinasCardapio.Shared.Handlers;
using Flunt.Notifications;

namespace DinasCardapio.Domain.Handlers
{
    public class ProductHandler : Notifiable, IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível criar o produto", Notifications);
            }

            var name = new Name(command.Name);
            var price = new Price(command.Price);
            var imageUrl = new ImageUrl(command.ImageUrl);
            var type = command.Type;

            var product = new Product(name, price, imageUrl, (EProductType)type, command.Size);

            AddNotifications(name, price, imageUrl);

            if (Invalid)
                return new CommandResult(false, "Não foi possível criar o produto", Notifications);

            _repository.PostAsync(product);

            return new CommandResult(true, "Produto criado com sucesso", product);
        }
    }
}
