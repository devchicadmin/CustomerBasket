using CustomerBasket.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBasket.Data.Services
{
	public class BasketCostService: IBasketCostService
	{
		/// <summary>
		/// calculate the cost - this may be extended for other scenarios, could sub class this into product helpers
		/// </summary>
		/// <param name="userId">user id </param>
		/// <param name="products">list of products in the basket</param>
		/// <returns>the basket</returns>
		public Basket CalculateBasketCost(int userId, List<Product> products)
		{
			double cost = Math.Round(products.Sum(product => product.Price),2);
			if(products.Where(product=> product.Name.Equals(ProductName.Butter)).Count() > 1)
			{
				var bread = products.Where(product => product.Name.Equals(ProductName.Bread)).FirstOrDefault();
				if (bread != null)
				{
					cost = cost - Math.Round((bread.Price / 2),2);
				}
			}
			var milkCount = products.Where(product => product.Name.Equals(ProductName.Milk)).Count();
			// TODO this wont allow for mutliple discounts
			if (milkCount > 3)
			{
				var milk = products.Where(product => product.Name.Equals(ProductName.Milk)).FirstOrDefault();
				if (milk != null)
				{
					cost = Math.Round(cost - milk.Price, 2);
				}
			}
			return new Basket
			{
				UserId = userId,
				Products = products,
				TotalCost = cost,
			};
		}
	}
}
