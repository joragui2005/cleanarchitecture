using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Item.Commands.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryEntity == null)
            {
                _logger.LogError($"Category not found, {request.Id}");
                throw new NotFoundException(nameof(Category), request.Id);
            }

            _mapper.Map(request, categoryEntity, typeof(UpdateCategoryCommand), typeof(Domain.Item));

            await _categoryRepository.UpdateAsync(categoryEntity, categoryEntity.Id);

            _logger.LogInformation($"The Category id:{categoryEntity.Id}, was updated");

            return Unit.Value;
        }
    }
}
