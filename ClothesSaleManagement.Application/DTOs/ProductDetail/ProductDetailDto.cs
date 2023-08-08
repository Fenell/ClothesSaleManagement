using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.Common;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Application.DTOs.ProductDetail
{
    public class ProductDetailDto:BaseDto
    {
	    public int Stock { get; set; }
	    public Size Size { get; set; }
	    public Guid ProductId { get; set; }
	}
}
