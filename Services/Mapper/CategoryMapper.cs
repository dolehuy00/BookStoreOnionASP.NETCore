using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.Mapper
{
    public class CategoryMapper
    {
        private readonly IMapper mapperToDTO;
        private readonly IMapper mapperToEntity;

        public CategoryMapper()
        {
            mapperToDTO = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            mapperToEntity = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()).CreateMapper();
        }

        public CategoryDTO ToDTO(Category category)
        {
            return mapperToDTO.Map<CategoryDTO>(category);
        }

        public Category ToEntity(CategoryDTO categoryDTO)
        {
            return mapperToEntity.Map<Category>(categoryDTO);
        }

        public ICollection<CategoryDTO> ToListDTO(ICollection<Category> categories)
        {
            return mapperToDTO.Map<ICollection<CategoryDTO>>(categories);
        }

        public ICollection<Category> ToListEntity(ICollection<CategoryDTO> categoryDTOs)
        {
            return mapperToEntity.Map<ICollection<Category>>(categoryDTOs);
        }
    }
}
