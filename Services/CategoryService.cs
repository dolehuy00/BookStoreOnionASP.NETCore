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

        public async Task<CategoryDTO> Add(CategoryDTO categoryDTO)
        {
            var category = _categoryMapper.ToEntity(categoryDTO);
            _genericRepo.Add(category);
            await _genericRepo.SaveChangesAsync();
            categoryDTO.Id = category.Id;
            return categoryDTO;
        }

        public async Task Delete(int categoryId)
        {
            _genericRepo.Delete(categoryId);
            await _genericRepo.SaveChangesAsync();
        }

        public async Task<CategoryDTO?> Get(int categoryId)
        {
            var category = await _genericRepo.GetByIdAsync(categoryId);
            if (category == null) return null;
            return _categoryMapper.ToDTO(category);
        }

        public async Task<ICollection<CategoryDTO>> GetAllCategories()
        {
            var cate = await _genericRepo.GetAllAsync();
            return _categoryMapper.ToListDTO(cate);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _categoryMapper.ToEntity(categoryDTO);
            _genericRepo.Update(category);
            await _genericRepo.SaveChangesAsync();
        }
    }
}
