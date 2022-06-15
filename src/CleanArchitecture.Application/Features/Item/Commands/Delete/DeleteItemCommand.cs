using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Features.Item.Commands.Delete
{
    public class DeleteItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
