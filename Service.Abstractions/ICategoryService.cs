using Shared;

namespace Service.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDTO>> GetAllCategories();
    }
}
