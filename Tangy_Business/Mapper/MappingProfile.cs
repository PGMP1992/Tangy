using AutoMapper;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Mapper
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            //CreateMap<CategoryDTO, Category>();
        }
    }
}
