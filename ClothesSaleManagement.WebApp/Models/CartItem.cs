using System.Reflection.Metadata.Ecma335;
using ClothesSaleManagement.Domain.Enums;
using Humanizer;

namespace ClothesSaleManagement.WebApp.Models
{
	public class CartItem
	{
		public Guid ProductDetailId { get; set; }
		public int Quantity { get; set; }
		public string Name { get; set; }
		public Size Size { get; set; }
		public string ImgUrl { get; set; }
		public decimal Price { get; set; }
		public Guid ProductId { get; set; }

		//read only
		public decimal TotalMoney => Quantity * Price;
	}
}
