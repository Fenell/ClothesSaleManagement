using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.WebApp.Models;
using Newtonsoft.Json;

namespace ClothesSaleManagement.WebApp.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        public ProductService(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        public async Task<List<ProductVM>> GetAllProduct()
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.GetAsync("api/Products");
            var stringContent = await response.Content.ReadAsStringAsync();
            var listProducts = JsonConvert.DeserializeObject<List<ProductVM>>(stringContent);

            return listProducts;
        }

        public async Task<ProductVM> GetProduct(Guid id)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var reponse = await client.GetAsync($"api/Products/{id}");
            var stringContent = await reponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ProductVM>(stringContent);
        }

        public async Task<Response<ProductCreateVM>> CreateProduct(ProductCreateVM product)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var requestContent = new MultipartFormDataContent();

            if (product.ImgFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(product.ImgFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)product.ImgFile.OpenReadStream().Length);
                }

                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "imgFile", product.ImgFile.FileName);
            }

            requestContent.Add(new StringContent(product.Name), "name");
            requestContent.Add(new StringContent(product.CategoryId.ToString()), "categoryId");
            requestContent.Add(new StringContent(product.Price.ToString()), "price");
            requestContent.Add(new StringContent(product.Description), "description");

            var response = await client.PostAsync("api/Products", requestContent);

            if (response.IsSuccessStatusCode)
            {
                return new Response<ProductCreateVM>() { IsSuscess = true, Data = product };
            }

            return new Response<ProductCreateVM>() { IsSuscess = false };
        }

        public async Task<Response<bool>> DeleteProduct(Guid id)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.DeleteAsync($"api/Products/{id}");

            if (response.IsSuccessStatusCode)
                return new Response<bool>() { IsSuscess = true };

            return new Response<bool>() { IsSuscess = false };
        }

        public async Task<Response<Guid>> UpdateProduct(Guid id, ProductUpdateVM product)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();

            if (product.ImgFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(product.ImgFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)product.ImgFile.OpenReadStream().Length);
                }

                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "imgFile", product.ImgFile.FileName);
            }

            requestContent.Add(new StringContent(product.Name), "name");
            requestContent.Add(new StringContent(product.CategoryId.ToString()), "categoryId");
            requestContent.Add(new StringContent(product.Price.ToString()), "price");
            requestContent.Add(new StringContent(product.Description), "description");

            var response = await client.PutAsync($"api/Products/{id}", requestContent);

            if (response.IsSuccessStatusCode)
            {
                return new Response<Guid>()
                {
                    IsSuscess = true,
                    Data = product.Id
                };
            }

            return new Response<Guid>()
            {
                IsSuscess = false
            };
        }

        public async Task<ProductDetailVm> GetProductDetail(Guid id)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.GetAsync($"api/Products/product-detail/{id}");
            var stringContent = await response.Content.ReadAsStringAsync();
            var productdetail = JsonConvert.DeserializeObject<ProductDetailVm>(stringContent);

            return productdetail;
        }

        public async Task<Response<Guid>> CreateSizeProduct(Guid productId, ProductDetailVm productDetailVm)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.PostAsJsonAsync($"api/Products/product-detail/{productId}", productDetailVm);

            if (response.IsSuccessStatusCode)
                return new Response<Guid>() { IsSuscess = true, };

            return new Response<Guid>() { IsSuscess = false };
        }

        public async Task<Response<bool>> UpdateStockAfterPay(List<ProductDetailDto> detailDtos)
        {
	        HttpClient client = _factory.CreateClient();
	        client.BaseAddress = new Uri(_config["BaseAddress"]);

	        var response = await client.PutAsJsonAsync("api/Products/update-stock-product", detailDtos);

            if (response.IsSuccessStatusCode)
	            return new Response<bool>() { IsSuscess = true };

            return new Response<bool>() { IsSuscess = false, Message = await response.Content.ReadAsStringAsync() };
        }

        public async Task<Response<Guid>> UpdateStockProduct(Guid productDetailId, ProductDetailVm productDetailVm)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.PutAsJsonAsync($"api/Products/product-detail/{productDetailId}", productDetailVm.Stock);

            if (response.IsSuccessStatusCode)
                return new Response<Guid>() { IsSuscess = true, Data = productDetailId };

            return new Response<Guid>() { IsSuscess = false, };
        }

    }

}
