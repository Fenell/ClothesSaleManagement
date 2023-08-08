using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using MediatR;

namespace ClothesSaleManagement.Application.Features.BillDetail.Requests
{
	public class GetListBillDetailRequest:IRequest<IQueryable<BillDetailDto>>
	{
		public Guid BillId { get; set; }
	}
}
