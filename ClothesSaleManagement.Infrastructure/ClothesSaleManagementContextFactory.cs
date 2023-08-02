using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClothesSaleManagement.Infrastructure
{
	public class ClothesSaleManagementContextFactory:IDesignTimeDbContextFactory<ClothesSaleManagementContext>
	{
		public ClothesSaleManagementContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			var connectionStrings = configuration.GetConnectionString("SaleManagement");

			var optionBuilder = new DbContextOptionsBuilder<ClothesSaleManagementContext>();
			optionBuilder.UseSqlServer(connectionStrings);

			return new ClothesSaleManagementContext(optionBuilder.Options);
		}
	}
}
