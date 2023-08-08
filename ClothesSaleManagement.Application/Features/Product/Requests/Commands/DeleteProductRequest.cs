using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Requests.Commands
{
    public class DeleteProductRequest:IRequest
    {
        public Guid Id { get; set; }
    }
}
