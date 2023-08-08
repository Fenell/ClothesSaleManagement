using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.WebApp.Models;

namespace ClothesSaleManagement.WebApp
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryDto, CategoryVM>().ReverseMap();

            CreateMap<ProductVM, ProductUpdateVM>().ReverseMap();

            CreateMap<CartItem, OrderDetailVM>().ForMember(dest => dest.ProductId,

	            opt =>
	            {
		            opt.MapFrom(src => src.ProductDetailId);
	            });


        }
    }
}
