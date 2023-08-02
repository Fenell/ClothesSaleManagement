using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain;
using ClothesSaleManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesSaleManagement.Infrastructure.Configuration
{
	public class BillConfig:IEntityTypeConfiguration<Bill>
	{
		public void Configure(EntityTypeBuilder<Bill> builder)
		{
			builder.ToTable("Bill");
			builder.HasKey(a => a.Id);
			builder.Property(a => a.TotalPayment).HasColumnType("decimal(18,2)");
			builder.Property(a => a.PhoneNumber).HasMaxLength(11).IsRequired();

			//Seeding data
			builder.HasData(
				new Bill()
				{
					Id = new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
					TotalPayment = 20000,
					CustomerName = "Lê Xuân Minh Chiến",
					Status = BillStatus.Paid,
					PhoneNumber = "0123123423",
					CreatedDate = DateTime.Now
				},
				new Bill()
				{
					Id = new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
					TotalPayment = 100000,
					CustomerName = "Nguyễn Ngọc Diệp ",
					Status = BillStatus.Paid,
					PhoneNumber = "0132312342",
					CreatedDate = DateTime.Now
				},
				new Bill()
				{
					Id = new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
					TotalPayment = 200000,
					CustomerName = "Nguyễn Ngọc Diệp",
					Status = BillStatus.Paid,
					PhoneNumber = "0132312342",
					CreatedDate = DateTime.Now
				});
		}
	}
}
