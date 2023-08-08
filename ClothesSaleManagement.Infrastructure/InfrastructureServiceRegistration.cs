using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Application.Repositories.Identity;
using ClothesSaleManagement.Infrastructure.Identity.Model;
using ClothesSaleManagement.Infrastructure.Implementations;
using ClothesSaleManagement.Infrastructure.Implementations.Identity;
using Microsoft.AspNetCore.Identity;
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
				opt.UseSqlServer(configuration.GetConnectionString("SaleManagement"), b => b.MigrationsAssembly(typeof(ClothesSaleManagementContext).FullName)));

			//services.AddIdentityCore<>(opt => opt.SignIn.RequireConfirmedAccount = false)
			//	.AddEntityFrameworkStores<ClothesSaleManagementContext>().AddDefaultTokenProviders();
			
			services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ClothesSaleManagementContext>().AddDefaultTokenProviders();

			//services.AddIdentityCore<ApplicationUser>(opt =>
			//	{

			//	}).AddSignInManager<SignInManager<ApplicationUser>>()
			//	.AddRoles<IdentityRole>()
			//	.AddRoleValidator<RoleValidator<IdentityRole>>()
			//	.AddRoleManager<RoleManager<IdentityRole>>();

			services.Configure<IdentityOptions>(opt =>
			{
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 3;
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IBillRepository, BillRepository>();
			services.AddScoped<IBillDetailRepository, BillDetailRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductDetailRepository, ProductDetailRepository>();

			services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
			services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
			services.AddScoped<IAuthService, AuthService>();

			return services;
		}
	}
}
