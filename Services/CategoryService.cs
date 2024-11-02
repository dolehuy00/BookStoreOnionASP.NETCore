using Domain.Entities;
using Domain.IRepositories;
using Service.Abstractions;
using Services.Mapper;
using Shared;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _genericRepo;
        private readonly CategoryMapper _categoryMapper;

        public CategoryService(IRepository<Category> genericRepo, CategoryMapper _mapper)
        {
            _genericRepo = genericRepo;
            _categoryMapper = _mapper;
        }
        public async Task<ICollection<CategoryDTO>> GetAllCategories()
        {
            var cate = await _genericRepo.GetAllAsync();
            return _categoryMapper.ToListDTO(cate);
        }
    }
}
