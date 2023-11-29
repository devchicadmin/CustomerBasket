using CustomerBasket.Shared.Models;


namespace CustomerBasket.Data.Repositories
{
	public interface IBasketProductRepository
	{
		List<Product> AddProduct(int userId, Product product);
		List<Product> Get(int userId);
		List<Product> RemoveProduct(int userId, Product product);
	}
}
