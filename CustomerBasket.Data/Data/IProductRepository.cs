using CustomerBasket.Shared.Models;

namespace CustomerBasket.Data.Data
{
	public interface IProductRepository
	{
		List<Product> GetProducts();
	}
}
