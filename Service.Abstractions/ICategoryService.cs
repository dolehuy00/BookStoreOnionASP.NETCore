using Shared;

namespace Service.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> Add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        Task Delete(int categoryId);
        Task<CategoryDTO?> Get(int categoryId);
    }
}
