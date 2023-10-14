using DinasCardapio.Domain.Entities;

namespace DinasCardapio.Domain.Queries
{
    public static class ProductQueries
    {
        public static Func<Product, bool> Get(Guid id)
        {
            return product =>
            {
                return product.Id == id;
            };
        }

        public static Func<Product, bool> Get(int type)
        {
            return product => (int)product.Type == type;
        }
    }
}
