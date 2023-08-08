using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Identity.Model
{
	public class ApplicationUserStore : UserStore<ApplicationUser,  IdentityRole<Guid>, ClothesSaleManagementContext, Guid>
	{
		public ApplicationUserStore(ClothesSaleManagementContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
	
}
