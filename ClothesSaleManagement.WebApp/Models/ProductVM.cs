using System.ComponentModel.DataAnnotations;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothesSaleManagement.WebApp.Models
{
	public class ProductVM : ProductCreateVM
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public Status Status { get; set; }
		public CategoryDto? CategoryDto { get; set; }
		public Guid ProductDetailId { get; set; }
		public int Quantity { get; set; }
		public IEnumerable<ProductDetailDto>? ProductDetailDtos { get; set; }
	}

	public class ProductCreateVM
	{
		[Display(Name = "Tên sản phẩm(*)")]
		[Required(ErrorMessage = "Không được để trống")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Giá(*)")]
		[Required(ErrorMessage = "Không được để trống")]
		[Range(1, Double.MaxValue, ErrorMessage = "Giá phải là số dương")]
		public decimal Price { get; set; }

		[Display(Name = "Mô tả chi tiết")]
		public string Description { get; set; } = string.Empty;

		[Display(Name = "Loại sản phẩm(*)")]
		[Required(ErrorMessage = "Không được để trống")]
		public Guid CategoryId { get; set; }
		public SelectList? SelectListCategory { get; set; }

		[Display(Name = "Ảnh sản phẩm")]
		public IFormFile? ImgFile { get; set; }
		public string ImageUrl { get; set; } = string.Empty;


	}

	public class ProductUpdateVM : ProductCreateVM
	{
		public Guid Id { get; set; }
		public IEnumerable<ProductDetailDto>? ProductDetailDtos { get; set; }


	}
}
