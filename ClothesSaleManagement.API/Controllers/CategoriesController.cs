using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.Features.Category.Request.Commands;
using ClothesSaleManagement.Application.Features.Category.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesSaleManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _mediator.Send(new GetCategoryListRequest());

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetCategoryDetailRequest() { Id = id });

			return Ok(response);
        }

		[HttpPost]
		public async Task<IActionResult> Create(CategoryDto dto)
        {
            var response = await _mediator.Send(new CreateCategoryRequest() { CategoryDto = dto });

			return Ok(response);
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, CategoryDto dto)
        {
             await _mediator.Send(new UpdateCategoryRequest() { Id = id, CategoryDto = dto });

			return NoContent();
        }
    }
}
