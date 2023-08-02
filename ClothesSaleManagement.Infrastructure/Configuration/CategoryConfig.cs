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
	public class CategoryConfig:IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Name).HasMaxLength(200).IsRequired();

			//Seeding data
			builder.HasData(
				new Category()
				{
					Id = new Guid("fe702e57-9cb1-4c9f-8157-b0d19b1a7c03"),
					Name = "Top tank",
					Status = Status.Active
				}, 
				new Category()
				{
					Id = new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"),
					Name = "T-Shirt",
					Status = Status.Active
				},
				new Category()
				{
					Id = new Guid("b4a85960-d2b0-45b6-8fed-015fe61b5016"),
					Name = "Áo phông",
					Status = Status.Active
				});
		}
	}
}
