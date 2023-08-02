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
	public class BillDetailConfig:IEntityTypeConfiguration<BillDetail>
	{
		public void Configure(EntityTypeBuilder<BillDetail> builder)
		{
			builder.ToTable("BillDetail");
			builder.HasKey(x => x.Id);
			builder.Property(a => a.Price).HasColumnType("decimal(18,2)");
			builder.Property(a => a.TotalMoney).HasColumnType("decimal(18,2)");
			builder.Property(a => a.Quantity).IsRequired();

			builder.HasOne<Bill>(a=>a.Bil)
				.WithMany(c=>c.BillDetails).HasForeignKey(a => a.BillId);

			builder.HasOne<Product>(a => a.Product)
				.WithMany(c => c.BillDetails).HasForeignKey(a => a.ProductId);


			//Seeding data
			builder.HasData(
				new BillDetail()
				{
					Id = new Guid("b8d733f0-6745-4be3-9072-39c4a52c803f"),
					BillId = new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
					ProductId = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
					Quantity = 1,
					Price = 20000,
					TotalMoney = 20000
				},
				new BillDetail()
				{
					Id = new Guid("18f91fdb-39d3-4fcc-b8ca-896ef777d840"),
					BillId = new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
					ProductId = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
					Quantity = 2,
					Price = 25000,
					TotalMoney = 50000
				},
				new BillDetail()
				{
					Id = new Guid("374bf0a6-039f-42a9-b232-e4c90998b4c2"),
					BillId = Guid.Parse("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
					ProductId = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
					Quantity = 5,
					Price = 10000,
					TotalMoney = 50000
				},
				new BillDetail()
				{
					Id = new Guid("574ee723-685c-4bfa-8235-44d085434b74"),
					BillId = new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
					ProductId = new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"),
					Quantity = 2,
					Price = 100000,
					TotalMoney = 200000
				});
		}
	}
}
