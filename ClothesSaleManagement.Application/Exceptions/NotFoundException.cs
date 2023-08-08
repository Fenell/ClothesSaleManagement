using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesSaleManagement.Application.Exceptions
{
	public class NotFoundException:ApplicationException
	{
		public NotFoundException(string name, object value):base($"{name}: {value} was not found")
		{

		}
	}
}
