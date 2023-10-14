using DinasCardapio.Shared.ValueObjects;
using Flunt.Validations;

namespace DinasCardapio.Domain.ValueObjects
{
    public class ImageUrl : ValueObject
    {
        public ImageUrl(string url)
        {
            Url = url;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(Url, "Url", "Url da imagem é obrigatória")
                        .IsUrl(Url, "Url", "Url inválida")
                );
        }

        public string Url { get;}
    }
}
