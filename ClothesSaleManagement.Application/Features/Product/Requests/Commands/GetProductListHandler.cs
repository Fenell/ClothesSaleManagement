using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.Features.Product.Requests.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Requests.Commands
{
	public class GetProductListHandler:IRequestHandler<GetProductListRequest, List<ProductDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetProductListHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
		{
			var listProduct = await _unitOfWork.ProductRepository.GetAllAsync();
			
			return 	_mapper.Map<List<ProductDto>>(listProduct);
		}
	}
}
