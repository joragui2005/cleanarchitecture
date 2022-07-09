using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryEntity == null)
            {
                _logger.LogError($"Category not found, {request.Id}");
                throw new NotFoundException(nameof(Category), request.Id);
            }

            await _categoryRepository.DeleteAsync(categoryEntity.Id);

            _logger.LogInformation($"The Category id:{categoryEntity.Id}, was deleted");

            return Unit.Value;
        }
    }
}
