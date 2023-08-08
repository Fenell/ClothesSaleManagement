using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;

namespace ClothesSaleManagement.Domain
{
	public class BillDetail:BaseDomainEntity
	{
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal TotalMoney { get; set; }

		//Relationship
		public Guid ProductDetailId { get; set; }
		public Guid BillId { get; set; }
		public ProductDetail? ProductDetail { get; set; }
		public Bill? Bil{ get; set; }
	}
}
