using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClothesSaleManagement.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ClothesSaleManagementContext>(opt =>
				opt.UseSqlServer(configuration.GetConnectionString("SaleManagement"),b =>b.MigrationsAssembly(typeof(ClothesSaleManagementContext).FullName)));

			//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IBillRepository, BillRepository>();
			services.AddScoped<IBillDetailRepository, BillDetailRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			return services;
		}
	}
}
