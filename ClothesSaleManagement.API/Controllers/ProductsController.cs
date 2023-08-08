using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Features.Product.Requests.Commands;
using ClothesSaleManagement.Application.Features.Product.Requests.Queries;
using ClothesSaleManagement.Application.Features.ProductDetail.Requests.Commands;
using ClothesSaleManagement.Application.Features.ProductDetail.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace ClothesSaleManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetProduct()
		{
			var response = await _mediator.Send(new GetProductListRequest());

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(Guid id)
		{
			var response = await _mediator.Send(new GetProductDetailRequest(id));

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromForm] CreateProductDto createProductDto)
		{
			var response = await _mediator.Send(new CreateProductResquest() { CreateProductDto = createProductDto});

			return Ok(response);
		}

		[HttpPut("{id}")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Put(Guid id,[FromForm] UpdateProductDto updateProduct)
		{
			await _mediator.Send(new UpdateProductRequest(){Id = id, UpdateProductDto = updateProduct});

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductRequest() { Id = id });

			return NoContent();
        }

		[HttpPost("product-detail/{productId}")]
		public async Task<IActionResult> CeateProductDetail(Guid productId, ProductDetailDto productDetailDto)
		{
			if (productId != productDetailDto.ProductId)
				return BadRequest("Product Id not match");

			var response = await _mediator.Send(new CreateProductDetailRequest() { ProductDetailDto = productDetailDto });

			return Ok(response);
		}

		[HttpPut("product-detail/{id}")]
		public async Task<IActionResult> UpdateProductDetail(Guid id, [FromBody] int addedQuantity)
		{
			await _mediator.Send(new UpdateProductDetailRequest() { Id = id, AddedQuantity = addedQuantity});

			return NoContent();
		}

		[HttpPut("update-stock-product")]
		public async Task<IActionResult> UpdateStockProductDetail(List<ProductDetailDto> detailDtos)
		{
			await _mediator.Send(new UpdateStockProductRequest() { ProductDetailDtos = detailDtos });

			return NoContent();
		}

		[HttpGet("product-detail/{id}")]
		public async Task<IActionResult> GetProductDetail(Guid id)
		{
			var productDetail = await _mediator.Send(new GetOnProductDetailRequest(){Id = id});

			return Ok(productDetail);
		}
	}
}
