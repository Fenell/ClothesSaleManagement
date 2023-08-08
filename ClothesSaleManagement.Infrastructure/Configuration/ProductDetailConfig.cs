using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain;
using ClothesSaleManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesSaleManagement.Infrastructure.Configuration
{
	public class ProductDetailConfig:IEntityTypeConfiguration<ProductDetail>
	{
		public void Configure(EntityTypeBuilder<ProductDetail> builder)
		{
			builder.ToTable("ProductDetail");
			builder.HasKey(x => x.Id);

			builder.HasOne<Product>(a=>a.Product)
				.WithMany(c=>c.ProductDetails).HasForeignKey(a=>a.ProductId);

			//Seeding data

			builder.HasData(
				new ProductDetail()
				{
					Id = new Guid("25e52937-d44f-4d2f-bc7f-67cbc6efd064"),
					ProductId = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
					Size = Size.S,
					Stock = 100
				},
				new ProductDetail()
				{
					Id = new Guid("056ac6f7-c203-4fcd-9727-6d702c2be6a5"),
					ProductId = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
					Size = Size.M,
					Stock = 200
				},
				new ProductDetail()
				{
					Id = new Guid("122a5c7d-33f9-461d-8451-06e325e852f6"),
					ProductId = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
					Size = Size.XXL,
					Stock = 100
				},
				new ProductDetail()
				{
					Id = new Guid("f288069e-65e0-404e-bc36-4409cb42a63d"),
					ProductId = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
					Size = Size.L,
					Stock = 50
				});
		}
	}
}
