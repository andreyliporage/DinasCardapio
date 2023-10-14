using DinasCardapio.Shared.ValueObjects;
using Flunt.Validations;

namespace DinasCardapio.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string name)
        {
            Title = name;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(Title, "Name", "Nome é obrigatório")
                        .HasMinLen(Title, 4, "Name", "Nome deve ter pelo menos 4 caracteres")
                );
        }

        public string Title { get; }
    }
}
