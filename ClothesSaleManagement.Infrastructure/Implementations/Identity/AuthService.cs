using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Models.Identity;
using ClothesSaleManagement.Application.Repositories.Identity;
using ClothesSaleManagement.Infrastructure.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace ClothesSaleManagement.Infrastructure.Implementations.Identity
{

	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public async Task<bool> Login(LoginRequest request)
		{
			var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, false);

			if (result.Succeeded)
				return true;
			return false;
		}

		public async Task<Guid> Resgister(RegisterRequest request)
		{
			var existingUser = await _userManager.FindByNameAsync(request.UserName);
			if (existingUser != null)
				throw new Exception($"User name {request.UserName} already exists");

			var user = new ApplicationUser()
			{
				UserName = request.UserName,
				FirstName = request.FirstName,
				LastName = request.LastName,
			};
			var result = await _userManager.CreateAsync(user, request.Password);
			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, "Customer");
				return user.Id;
			}

			throw new Exception("Register fail");
		}

		public async Task Logout()
		{
			await _signInManager.SignOutAsync();
		}
	}
}
