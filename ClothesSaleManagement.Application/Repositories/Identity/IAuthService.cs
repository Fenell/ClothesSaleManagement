using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Models.Identity;

namespace ClothesSaleManagement.Application.Repositories.Identity
{
	public interface IAuthService
	{
		Task<bool> Login(LoginRequest request);
		Task<Guid> Resgister(RegisterRequest request);
		Task Logout();
	}
}
