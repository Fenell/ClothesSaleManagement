using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Category;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Category.Request.Commands
{
    public class UpdateCategoryRequest:IRequest
    {
        public Guid Id { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
