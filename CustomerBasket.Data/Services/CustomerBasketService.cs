using CustomerBasket.Data.Repositories;
using CustomerBasket.Shared.Models;
using System;
using System.Collections.Generic;


namespace CustomerBasket.Data.Services
{
    public class CustomerBasketService: ICustomerBasketService
	{
		private IBasketProductRepository _basketProductRepository;
		private IBasketCostService _basketCostService;
		public CustomerBasketService(IBasketProductRepository basketProductRepository, IBasketCostService basketCostService)
        {
			_basketProductRepository = basketProductRepository;
			_basketCostService = basketCostService;
		}
		/// <summary>
		/// Gets a Basket for a user id
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <returns>Basket</returns>
		public Basket Get(int userId)
		{
			var products = _basketProductRepository.Get(userId);
			return _basketCostService.CalculateBasketCost(userId, products);
		}

		/// <summary>
		/// Adds a product to the basket
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <param name="product">Product to add</param>
		/// <returns>Basket</returns>
		public Basket AddProduct(int userId, Product product)
		{
			var products = _basketProductRepository.AddProduct(userId, product);
			return _basketCostService.CalculateBasketCost(userId, products);
		}

		/// <summary>
		/// Rmmoves a product from the basket
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <param name="product">Product to remove</param>
		/// <returns>Basket</returns>
		/// <exception cref="NotImplementedException"></exception>
		public Basket RemoveProduct(int userId, Product product)
		{
			throw new NotImplementedException();
		}
	}
}
;