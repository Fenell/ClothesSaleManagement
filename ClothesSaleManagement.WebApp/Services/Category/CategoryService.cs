using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.WebApp.Models;
using Newtonsoft.Json;

namespace ClothesSaleManagement.WebApp.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        public CategoryService(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }
        public async Task<List<CategoryVM>> GetAll()
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.GetAsync("api/Categories");
            var stringContent = await response.Content.ReadAsStringAsync();
            var categoryVms = JsonConvert.DeserializeObject<List<CategoryVM>>(stringContent);

            return categoryVms;
        }

        public async Task<Response<CategoryVM>> GetById(Guid id)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.GetAsync($"api/Categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryVM>(stringContent);
                return new Response<CategoryVM>()
                {
                    IsSuscess = true,
                    Data = category
                };
            }
            return new Response<CategoryVM>()
            {
                IsSuscess = false,
                Message = response.Content.ToString()
            };
        }

        public async Task<Response<CategoryVM>> Create(CategoryVM categoryVM)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            var response = await client.PostAsJsonAsync("api/Categories", categoryVM);
            if (response.IsSuccessStatusCode)
            {
                return new Response<CategoryVM>()
                {
                    IsSuscess = true,
                    Data = categoryVM
                };
            }
            return new Response<CategoryVM>()
            {
                IsSuscess = false,
                Message = response.Content.ToString()
            };
        }

        public async Task Update(Guid id, CategoryVM categoryVM)
        {
            HttpClient client = _factory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);

            await client.PutAsJsonAsync($"api/Categories/{id}", categoryVM);
        }
    }
}
