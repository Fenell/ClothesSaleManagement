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

			builder.HasOne<ProductDetail>(c => c.ProductDetail).WithMany(a => a.BillDetails)
				.HasForeignKey(c => c.ProductDetailId);

			//Seeding data
			builder.HasData(
				new BillDetail()
				{
					Id = new Guid("b8d733f0-6745-4be3-9072-39c4a52c803f"),
					BillId = new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
					ProductDetailId = new Guid("25e52937-d44f-4d2f-bc7f-67cbc6efd064"),
					Quantity = 1,
					Price = 20000,
					TotalMoney = 20000
				},
				new BillDetail()
				{
					Id = new Guid("18f91fdb-39d3-4fcc-b8ca-896ef777d840"),
					BillId = new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
					ProductDetailId = new Guid("122a5c7d-33f9-461d-8451-06e325e852f6"),
					Quantity = 2,
					Price = 25000,
					TotalMoney = 50000
				},
				new BillDetail()
				{
					Id = new Guid("374bf0a6-039f-42a9-b232-e4c90998b4c2"),
					BillId = Guid.Parse("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
					ProductDetailId = new Guid("056ac6f7-c203-4fcd-9727-6d702c2be6a5"),
					Quantity = 5,
					Price = 10000,
					TotalMoney = 50000
				},
				new BillDetail()
				{
					Id = new Guid("574ee723-685c-4bfa-8235-44d085434b74"),
					BillId = new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
					ProductDetailId = new Guid("122a5c7d-33f9-461d-8451-06e325e852f6"),
					Quantity = 2,
					Price = 100000,
					TotalMoney = 200000
				});
		}
	}
}
