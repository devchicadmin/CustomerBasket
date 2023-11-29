using CustomerBasket.Data.Services;
using CustomerBasket.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBasket.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class BasketController : ControllerBase
	{
		// todo implement logging
		private readonly ILogger<BasketController> _logger;
		private ICustomerBasketService _customerBasketService;

		public BasketController(ILogger<BasketController> logger, ICustomerBasketService customerBasketService)
		{
			_logger = logger;
			_customerBasketService = customerBasketService;
		}

		/// <summary>
		/// Gets a product basket for a user id
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <returns>Basket</returns>

		[HttpGet(Name = "Get")]
		public IActionResult Get(int userId)
		{
			// todo implement logging
			return Ok(_customerBasketService.Get(userId));
			
		}

		[HttpPost(Name = "Add")]
		public IActionResult Add(int userId, [FromBody]Product product)
		{
			// todo implement logging
			var basket = _customerBasketService.AddProduct(userId, product);
			return Ok(basket);

		}

		[HttpDelete(Name = "Remove")]
		public IActionResult Remove(int userId, Product product)
		{
			// todo implement logging
			var basket = _customerBasketService.RemoveProduct(userId, product);
			return Ok(basket);

		}
	}
}