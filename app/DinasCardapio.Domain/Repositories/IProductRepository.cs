using DinasCardapio.Domain.Entities;
using DinasCardapio.Domain.ViewModels;

namespace DinasCardapio.Domain.Repositories
{
    public interface IProductRepository
    {
        int PostAsync(Product product);
        ResultViewModel<ProductViewModel> GetAsync(Guid productId);
        ResultViewModel<List<ProductViewModel>> GetAsync();
        ResultViewModel<List<ProductViewModel>> GetAsync(int type);
    }
}
