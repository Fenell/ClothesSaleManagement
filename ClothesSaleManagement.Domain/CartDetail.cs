﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain.Common;

namespace ClothesSaleManagement.Domain
{
	public class CartDetail:BaseDomainEntity
	{
		public int Quantity { get; set; }

		//Relationship
		public Guid CartId { get; set; }
		public Guid ProductDetailId { get; set; }
		public ProductDetail? ProductDetail { get; set; }
		public Cart? Cart{ get; set; }
	}
}
