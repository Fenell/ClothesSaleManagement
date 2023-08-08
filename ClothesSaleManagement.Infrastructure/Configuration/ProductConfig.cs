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
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Product");
			builder.HasKey(a => a.Id);
			builder.Property(a => a.Name).HasMaxLength(200).IsRequired();
			builder.Property(a => a.Price).HasColumnType("decimal(18,2)");
			builder.Property(a => a.CostPrice).HasColumnType("decimal(18,2)");

			builder.HasOne<Category>(a => a.Category)
				.WithMany(c => c.Products).HasForeignKey(c => c.CategoryId);

			//Seeding data
			builder.HasData(
				new Product
				{
					Id = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
					CategoryId = new Guid("fe702e57-9cb1-4c9f-8157-b0d19b1a7c03"),
					Name = "Áo phông chanh xả",
					CostPrice = 50000,
					Price = 100000,
					Description = "Sang xịn mịn",
					CreatedDate = DateTime.Now,
					Status = Status.Active,
				},
				new Product
				{
					Id = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
					CategoryId = new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"),
					Name = "Áo top tank sẹc xi",
					CostPrice = 20000,
					Price = 50000,
					Description = "Sang xịn mịn",
					CreatedDate = DateTime.Now,
					Status = Status.Active,
				},
				new Product()
				{
					Id = new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"),
					CategoryId = new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"),
					Name = "Áo T-shirt co dãn",
					CostPrice = 20000,
					Price = 50000,
					Description = "Thoáng mát",
					CreatedDate = DateTime.Now,
					Status = Status.Active,
				});
		}
	}
}
