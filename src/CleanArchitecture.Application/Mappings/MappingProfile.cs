using AutoMapper;
using CleanArchitecture.Application.Features.Category.Commands.Create;
using CleanArchitecture.Application.Features.Category.Commands.Update;
using CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList;
using CleanArchitecture.Application.Features.Item.Commands.Create;
using CleanArchitecture.Application.Features.Item.Commands.Update;
using CleanArchitecture.Application.Features.Item.Querys.GetItemsList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryVm>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Item, ItemVm>();
            CreateMap<CreateItemCommand, Item>();
            CreateMap<UpdateItemCommand, Item>();
        }
    }
}
