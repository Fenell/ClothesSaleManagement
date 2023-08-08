using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain;
using ClothesSaleManagement.Infrastructure.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure
{
	public class ClothesSaleManagementContext:IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public ClothesSaleManagementContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Bill> Bills { get; set; }
		public DbSet<BillDetail> BillDetails { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartDetail> CartDetails { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductDetail> ProductDetails { get; set; }
	}
}
