using CustomerBasket.Shared.Models;
using Microsoft.Extensions.Caching.Memory;


namespace CustomerBasket.Data.Repositories
{
	public class BasketProductRepository: IBasketProductRepository
	{
		private const string BasketCacheKey = "CustomerBasketStore";
		private readonly IMemoryCache _memoryCache;

		public BasketProductRepository(IMemoryCache memoryCache) =>
		_memoryCache = memoryCache;

		/// <summary>
		/// Gets the Products in a basket for a user id from the in memory store - can be changed to another store or db
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <returns>List<Product></returns>
		public List<Product> Get(int userId)
		{
			var cacheKey = $"{BasketCacheKey}-{userId}";

			var products = _memoryCache.Get<List<Product>>(cacheKey);
			return products == null ? new List<Product>() : products;

		}

		public List<Product> AddProduct(int userId, Product product)
		{
			var cacheKey = $"{BasketCacheKey}-{userId}";

			if (!_memoryCache.TryGetValue(cacheKey, out DateTime CachedtDateTime))
			{
				_memoryCache.Set(cacheKey, new List<Product>() { product });
				// can change this to another repo like db, json, and use expirations for cache
			}
			else
			{
				var products = _memoryCache.Get<List<Product>>(cacheKey);
				products?.Add(product);
				_memoryCache.Set(cacheKey, products);
			}
			return Get(userId);
		}

		public List<Product> RemoveProduct(int userId, Product product)
		{
			throw new NotImplementedException();
		}
	}
}
