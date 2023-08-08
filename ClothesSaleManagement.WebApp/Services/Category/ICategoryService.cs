using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.WebApp.Models;

namespace ClothesSaleManagement.WebApp.Services.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAll();
        Task<Response<CategoryVM>> GetById(Guid id);

        Task<Response<CategoryVM>> Create(CategoryVM categoryVM);

        Task Update(Guid id, CategoryVM categoryVM);

    }
}
