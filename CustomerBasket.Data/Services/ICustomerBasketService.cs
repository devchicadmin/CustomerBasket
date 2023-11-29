using CustomerBasket.Shared.Models;

namespace CustomerBasket.Data.Services
{
    public interface ICustomerBasketService
    {
        Basket Get(int userId);
        Basket AddProduct(int userId, Product name);
        Basket RemoveProduct(int userId, Product name);
    }
}