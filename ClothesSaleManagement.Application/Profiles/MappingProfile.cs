using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Domain;
using ProductDetailDto = ClothesSaleManagement.Application.DTOs.ProductDetail.ProductDetailDto;

namespace ClothesSaleManagement.Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			#region Product mapping

			CreateMap<Product, ProductDto>().ReverseMap();

			CreateMap<Product, CreateProductDto>().ReverseMap();

			CreateMap<Product, UpdateProductDto>().ReverseMap().ForMember(dest=> dest.Id, opt=>opt.Ignore());
			#endregion

			CreateMap<Bill, BillDto>().ReverseMap();
			CreateMap<BillDetail, BillDetailDto>().ReverseMap();
			CreateMap<BillDetail, BillDetailCreateDto>().ReverseMap();
			CreateMap<Bill, BillCreateDto>().ReverseMap();


			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<ProductDetail, ProductDetailDto>().ReverseMap();

		}
	}
}
