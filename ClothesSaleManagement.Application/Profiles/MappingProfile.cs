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
using ClothesSaleManagement.Domain;

namespace ClothesSaleManagement.Application.Profiles
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Bill, BillDto>().ReverseMap();

			CreateMap<BillDetail, BillDetailDto>().ReverseMap();

			CreateMap<Category, CategoryDto>().ReverseMap();

			CreateMap<Product, ProductDto>().ReverseMap();
		}
	}
}
