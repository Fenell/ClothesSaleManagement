﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using MediatR;

namespace ClothesSaleManagement.Application.Features.ProductDetail.Requests.Commands
{
	public class UpdateStockProductRequest:IRequest
	{
		public List<ProductDetailDto> ProductDetailDtos { get; set; }
	}
}
