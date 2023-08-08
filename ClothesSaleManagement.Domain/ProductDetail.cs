using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;
using ClothesSaleManagement.Domain.Enums;


namespace ClothesSaleManagement.Domain
{
	public class ProductDetail:BaseDomainEntity
	{
		public int Stock { get; set; }
		public Size Size { get; set; } 

		public Guid ProductId { get; set; }
		public virtual Product? Product { get; set; }

		public virtual IEnumerable<BillDetail>? BillDetails { get; set; }

		public virtual IEnumerable<CartDetail>? CartDetails{ get; set; }

	}
}
