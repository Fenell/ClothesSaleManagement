using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesSaleManagement.Infrastructure.Configuration
{
	public class CartDetailConfig:IEntityTypeConfiguration<CartDetail>
	{
		public void Configure(EntityTypeBuilder<CartDetail> builder)
		{
			builder.ToTable("CartDetail");
			builder.HasKey(a=>a.Id);
			builder.Property(a => a.Quantity).HasDefaultValue(1);

			builder.HasOne<ProductDetail>(c => c.ProductDetail).WithMany(a => a.CartDetails)
				.HasForeignKey(a => a.ProductDetailId);

			builder.HasOne<Cart>(a => a.Cart)
				.WithMany(c => c.CartDetails).HasForeignKey(a => a.CartId);
		}
	}
}
