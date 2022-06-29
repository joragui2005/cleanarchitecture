using MediatR;

namespace CleanArchitecture.Application.Features.Item.Querys.GetItemsList
{
    public class GetItemsListQuery : IRequest<List<ItemVm>>
    {
        public int Id { get; set; }
        public GetItemsListQuery(int id)
        {
            Id = id;
        }

        public GetItemsListQuery()
        {
        }
    }
}
