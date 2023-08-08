﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Bill;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Bill.Requests
{
	public class GetBillRequest:IRequest<BillDto>
	{
		public Guid Id { get; set; }
	}
}
