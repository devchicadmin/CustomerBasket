namespace CustomerBasket.Shared.Models
{
    public class Basket
    {
        public Basket()
        {
                Products = new List<Product>();
        }
        /// <summary>
        /// The User Id the basket belongs to - could in the future use a User object here
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// List of Products in the basket
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// The Total Price - could in future seperate to  cost, discount, total
        /// </summary>
        public double TotalCost { get; set; }

	}
}