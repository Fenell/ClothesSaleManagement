using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.WebApp.Models;
using Newtonsoft.Json;

namespace ClothesSaleManagement.WebApp.Services.Bill
{
    public class BillService:IBillService
    {
	    private readonly IHttpClientFactory _factory;
	    private readonly IConfiguration _config;

	    public BillService(IHttpClientFactory factory, IConfiguration config)
	    {
		    _factory = factory;
		    _config = config;
	    }
	    public async Task<List<BillDto>> GetListBill()
	    {
		    HttpClient client = _factory.CreateClient();
		    client.BaseAddress = new Uri(_config["BaseAddress"]);

		    var response = await client.GetAsync("api/Bills");

			var jsonContent = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<List<BillDto>>(jsonContent);
	    }

	    public async Task<List<BillDetailDto>> GetListBillDetail(Guid billId)
	    {
		    HttpClient client = _factory.CreateClient();
		    client.BaseAddress = new Uri(_config["BaseAddress"]);

		    var response = await client.GetAsync($"api/Bills/bill-detail/{billId}");
			var jsonContent = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<List<BillDetailDto>>(jsonContent);

	    }

	    public async Task<Response<Guid>> Create(OrderVM orderVm)
	    {
		    HttpClient httpClient = CreateClient();

		    var response = await httpClient.PostAsJsonAsync("api/Bills", orderVm);
			if (response.IsSuccessStatusCode)
			{
				var jsonContent= await response.Content.ReadAsStringAsync();
				var billId = JsonConvert.DeserializeObject<Guid>(jsonContent);
				return new Response<Guid>() { IsSuscess = true, Data =billId };
			}

			return new Response<Guid>() { IsSuscess = false, Message = await response.Content.ReadAsStringAsync() };
	    }

	    public async Task<Response<bool>> CreateBillDetail(Guid billId, List<BillDetailCreateDto> billDetailCreateDtos)
	    {
		    HttpClient httpClient = CreateClient();

		    var response = await httpClient.PostAsJsonAsync($"api/Bills/bill-detail/{billId}", billDetailCreateDtos);

			if (response.IsSuccessStatusCode)
			{
				return new Response<bool>() { IsSuscess = true };
			}

			return new Response<bool>() { IsSuscess = false , Message = await response.Content.ReadAsStringAsync()};
	    }

		private HttpClient CreateClient()
		{
			HttpClient client = _factory.CreateClient();
			client.BaseAddress = new Uri(_config["BaseAddress"]);
			return client;
		}
    }
}
