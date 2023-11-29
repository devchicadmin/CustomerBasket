

using System.Runtime.Serialization;

namespace CustomerBasket.Shared.Models
{
	public class Product
	{
		/// <summary>
		/// the Name of the Product
		/// </summary>
		public ProductName Name { get; set; }
		/// <summary>
		/// The Base Price of the Product
		/// </summary>
		public double Price { get; set; }
	}

	public enum ProductName
	{
		[EnumMember(Value = "Butter")]
		Butter,
		[EnumMember(Value = "Milk")]
		Milk,
		[EnumMember(Value = "Bread")]
		Bread

	}
}
