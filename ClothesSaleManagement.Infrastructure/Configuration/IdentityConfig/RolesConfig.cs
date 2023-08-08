using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothesSaleManagement.Infrastructure.Configuration.IdentityConfig
{
	public class RolesConfig:IEntityTypeConfiguration<IdentityRole<Guid>>
	{
		public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
		{
			builder.HasData(
				new IdentityRole<Guid>
				{
					Id = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
					Name = "Customer",
					NormalizedName = "CUSTOMER"
				},
				new IdentityRole<Guid>
				{
					Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
					Name = "Administrator",
					NormalizedName = "ADMINISTRATOR"
				}
			);
		}
	}
}
