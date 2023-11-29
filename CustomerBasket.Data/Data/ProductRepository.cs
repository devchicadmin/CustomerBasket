using CustomerBasket.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBasket.Data.Data
{
	public class ProductRepository: IProductRepository
	{
		/// <summary>
		/// Gets a list of avaiable products - replace to get from Stored proc or json file
		/// </summary>
		/// <returns>List<Product></returns>
		public List<Product> GetProducts() {
			return new List<Product>
			{
				new Product
				{
					Name = ProductName.Butter,
					Price = 0.80,
				},
				new Product
				{
					Name=ProductName.Bread,
					Price = 1.00

				},
					new Product
				{
					Name=ProductName.Milk,
					Price = 1.15

				}
			};
		}
	}

}
