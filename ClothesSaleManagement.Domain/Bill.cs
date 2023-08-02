using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Domain
{
	public class Bill : BaseDomainEntity
	{
		public DateTime CreatedDate { get; set; }
		public decimal TotalPayment { get; set; }
		public string CustomerName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public BillStatus Status { get; set; }

		//Relationship
		public IEnumerable<BillDetail>? BillDetails { get; set; }
	}
}
