using System.ComponentModel.DataAnnotations;
using ClothesSaleManagement.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothesSaleManagement.WebApp.Models
{
	public class ProductDetailVm
	{
		public Guid Id { get; set; }

		[Display(Name = "Số lượng(*)")]
		[Range(1,Int32.MaxValue,ErrorMessage = "Số lượng phải là số dương")]
		[Required(ErrorMessage = "Không để trống")]
		public int Stock { get; set; }
        public Size Size { get; set; }
		public SelectList? SizeSelectList { get; set; }
		public Guid ProductId { get; set; }
	}
}
