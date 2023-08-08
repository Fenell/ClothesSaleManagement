using ClothesSaleManagement.Domain;

namespace ClothesSaleManagement.Application.Repositories
{
	public interface IBillRepository:IGenericRepository<Bill>
	{
		Task<Bill> GetBillAsync(Guid id);
		Task<List<Bill>> GetListBillAsync();
	}
}
