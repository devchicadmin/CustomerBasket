using CustomerBasket.Data.Data;
using CustomerBasket.Data.Services;
using CustomerBasket.Shared.Models;

namespace CustomerBasket.Tests
{
	[TestClass]
	public class BasketCostServiceTests
	{
		private readonly IBasketCostService _basketCostService;
		private readonly IProductRepository _productRepository;
		private const int USER_ID = 1;
		public BasketCostServiceTests()
		{
			_basketCostService = new BasketCostService();
			_productRepository = new ProductRepository();
		}

		[TestMethod]
		public void Given_I_Have_One_Of_Each_Product_Then_Cost_Equals_295()
		{
			var expectedCost = 2.95;
			var basket = _basketCostService.CalculateBasketCost(USER_ID, _productRepository.GetProducts());
			Assert.IsNotNull(basket);
			Assert.AreEqual(expectedCost, basket.TotalCost);
		}


		[TestMethod]
		public void Given_When_2_Butter_And_2_Bread_Then_Cost_Equals_310()
		{
			var expectedCost = 3.10;
			// could use  a builder pattern here for dummy products list
			// https://betterprogramming.pub/improve-code-readability-with-fluent-builder-pattern-in-c-4cfbf57159df
			var products = new List<Product>
			{
				new Product
			{
				Name = ProductName.Butter,
				Price = 0.80,
			},
				new Product
			{
				Name = ProductName.Butter,
				Price = 0.80,
			},
			new Product
			{
				Name = ProductName.Bread,
				Price = 1.00

			},
			new Product
			{
				Name = ProductName.Bread,
				Price = 1.00

				},
			};
			var basket = _basketCostService.CalculateBasketCost(USER_ID, products);
			Assert.IsNotNull(basket);
			Assert.AreEqual(expectedCost, basket.TotalCost);
		}

		[TestMethod]
		public void Given_When_4_Milk_Then_Cost_Equals_345()
		{
			var expectedCost = 3.45;
			// could use  a builder pattern here for dummy products list
			var products = new List<Product>
			{
				new Product
			{
				Name = ProductName.Milk,
				Price =1.15
			},
				new Product
			{
				Name = ProductName.Milk,
				Price =1.15
			},
			new Product
			{
				Name = ProductName.Milk,
				Price = 1.15

			},
			new Product
			{
				Name = ProductName.Milk,
				Price = 1.15

			},
			};
			var basket = _basketCostService.CalculateBasketCost(USER_ID, products);
			Assert.IsNotNull(basket);
			Assert.AreEqual(expectedCost, basket.TotalCost);
		}

		[TestMethod]
		public void Given_When_2_Butter_1_Bread_8_Milk_Then_Cost_Equals_9()
		{
			var expectedCost = 9;
			// could use  a builder pattern here for dummy products list
			var products = new List<Product>
			{
			new Product
			{
				Name = ProductName.Butter,
				Price = 0.80,
			},
			new Product
			{
				Name = ProductName.Butter,
				Price = 0.80,
			},
			new Product
			{
				Name = ProductName.Bread,
				Price = 1.00

			},
				new Product
			{
				Name = ProductName.Milk,
				Price =1.15
			},
				new Product
			{
				Name = ProductName.Milk,
				Price =1.15
			},
			new Product
			{
				Name = ProductName.Milk,
				Price = 1.15

			},
			new Product
			{
				Name = ProductName.Milk,
				Price = 1.15

			},
				new Product
			{
				Name = ProductName.Milk,
				Price =1.15
			},
				new Product
			{
				Name = ProductName.Milk,
				Price =1.15
			},
			new Product
			{
				Name = ProductName.Milk,
				Price = 1.15

			},
			new Product
			{
				Name = ProductName.Milk,
				Price = 1.15

			}
			};
			var basket = _basketCostService.CalculateBasketCost(USER_ID, products);
			Assert.IsNotNull(basket);
			Assert.AreEqual(expectedCost, basket.TotalCost);
		}
	}
}