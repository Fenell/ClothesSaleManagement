using System.ComponentModel.DataAnnotations;

namespace ClothesSaleManagement.WebApp.Models
{
	public class OrderVM
	{
		public decimal TotalPayment { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập tên")]
		public string CustomerName { get; set; } = string.Empty;

		[MaxLength(10)]
		[Required(ErrorMessage = "Vui lòng nhập số điện thoại")]

		public string PhoneNumber { get; set; } = string.Empty;

		public List<CartItem>? CurrentCartItem { get; set; }
	}
}
