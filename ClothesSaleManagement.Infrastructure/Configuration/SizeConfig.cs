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
	public class SizeConfig:IEntityTypeConfiguration<Size>
	{
		public void Configure(EntityTypeBuilder<Size> builder)
		{
			builder.ToTable("Size");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(10).IsRequired().IsUnicode(false);

			//Seeding data
			builder.HasData(
				new Size()
				{
					Id = new Guid("f306c6f6-8a72-4c20-9031-2310cf8bf042"),
					Name = "S",
				},
				new Size()
				{
					Id = new Guid("2a765a9f-2dca-41d3-9570-e1ce39dc1f28"),
					Name = "M",
				},
				new Size()
				{
					Id = new Guid("af100821-2fd2-4d2d-a95e-04c772bceeb6"),
					Name = "L",
				});
		}
	}
}
