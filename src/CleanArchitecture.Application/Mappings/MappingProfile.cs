using AutoMapper;
using CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList;
using CleanArchitecture.Application.Features.Item.Commands.Create;
using CleanArchitecture.Application.Features.Item.Querys.GetItemsList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryVm>();
            CreateMap<Item, ItemVm>();
            CreateMap<CreateItemCommand, Item>();

        }
    }
}
