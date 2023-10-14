using DinasCardapio.Shared.ValueObjects;
using Flunt.Validations;

namespace DinasCardapio.Domain.ValueObjects
{
    public class Price : ValueObject
    {
        public Price(decimal price)
        {
            Value = price;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNull(Value, "Price", "Valor é obrigatório")
                        .IsGreaterThan(Value, 0, "Price", "Valor deve ser maior que zero")
                );
        }

        public decimal Value { get; }
    }
}
