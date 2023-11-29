

using CustomerBasket.Shared.Models;

namespace CustomerBasket.Data.Services
{
	public interface IBasketCostService
	{
		Basket CalculateBasketCost(int userId, List<Product> products);
	}
}
