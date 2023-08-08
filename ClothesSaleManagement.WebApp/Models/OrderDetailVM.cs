namespace ClothesSaleManagement.WebApp.Models
{
	public class OrderDetailVM
	{
		public Guid Id { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid ProductId { get; set; }
		
		public decimal TotalMoney => Price * Quantity;
	}
}
