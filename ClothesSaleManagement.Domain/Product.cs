using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Domain
{
	public class Product : BaseDomainEntity
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal CostPrice { get; set; }
		public int AvailableQuantity { get; set; }
		public string Description { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
		public Status Status { get; set; }

		//Relationship
		public Guid CategoryId { get; set; }
		public virtual Category? Category { get; set; }

		public Guid SizeId { get; set; }
		public virtual Size? Size { get; set; }

		public IEnumerable<BillDetail>? BillDetails { get; set; }

		public IEnumerable<CartDetail>? CartDetails{ get; set; }
	}
}
