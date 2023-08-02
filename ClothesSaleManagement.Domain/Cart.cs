using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;

namespace ClothesSaleManagement.Domain
{
	public class Cart:BaseDomainEntity
	{
		public string Description { get; set; } = string.Empty;

		//Relationship
		public IEnumerable<CartDetail>? CartDetails { get; set; }
	}
}
