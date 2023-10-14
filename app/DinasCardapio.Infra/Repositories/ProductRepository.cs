using DinasCardapio.Domain.Entities;
using DinasCardapio.Domain.Queries;
using DinasCardapio.Domain.Repositories;
using DinasCardapio.Domain.ViewModels;
using DinasCardapio.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DinasCardapio.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DinasDataContext _dataContext;

        public ProductRepository(DinasDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ResultViewModel<ProductViewModel> GetAsync(Guid productId)
        {
            try
            {
                var product = _dataContext.Products.FirstOrDefault(ProductQueries.Get(productId));
                if (product is null)
                    return new ResultViewModel<ProductViewModel>("Conteúdo não encontrado");
                
                return new ResultViewModel<ProductViewModel>(new ProductViewModel(product));
            }
            catch (DbUpdateException)
            {
                throw new Exception("Erro interno no servidor");
            }
        }

        public ResultViewModel<List<ProductViewModel>> GetAsync()
        {
            try
            {
                var products = _dataContext.Products.ToList();
                var productsViewModel = new List<ProductViewModel>();

                products.ForEach(product => productsViewModel.Add(new ProductViewModel(product)));

                return new ResultViewModel<List<ProductViewModel>>(productsViewModel);

            }
            catch (DbUpdateException)
            {
               throw new Exception("Erro interno no servidor");
            }
        }

        public ResultViewModel<List<ProductViewModel>> GetAsync(int type)
        {
            try
            {
                var products = _dataContext.Products.Where(ProductQueries.Get(type)).ToList();
                var productsViewModel = new List<ProductViewModel>();
                products.ForEach(product => productsViewModel.Add(new ProductViewModel(product)));

                return new ResultViewModel<List<ProductViewModel>>(productsViewModel);
            }
            catch (DbUpdateException)
            {
                throw new Exception("Erro interno no servidor");
            }
        }

        public int PostAsync(Product product)
        {
            try
            {
                _dataContext.Add(product);
                return _dataContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new Exception("Erro interno no servidor");
            }
        }
    }
}
