using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Domain
{
	public class Category:BaseDomainEntity
	{
		public string Name { get; set; } = string.Empty;
		public Status Status { get; set; }

		//Relationship
		public virtual IEnumerable<Product>? Products { get; set; }
	}
}
