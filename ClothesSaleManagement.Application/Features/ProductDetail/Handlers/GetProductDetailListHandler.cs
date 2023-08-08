using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Features.ProductDetail.Requests.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.ProductDetail.Handlers
{
    public class GetProductDetailListHandler : IRequestHandler<GetProductDetailListRequest, List<ProductDetailDto>>
    {
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IMapper _mapper;

        public GetProductDetailListHandler(IProductDetailRepository productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDetailDto>> Handle(GetProductDetailListRequest request, CancellationToken cancellationToken)
        {
            var listProductDetail = await _productDetailRepository.GetProductDetail(request.ProductId);

            return _mapper.Map<List<ProductDetailDto>>(listProductDetail);
        }
    }
}
