using MediatR;
using vertical_slicing_demo.Models;
using vertical_slicing_demo.Repositories;

namespace vertical_slicing_demo.Common.BaseHandlers
{
    public class BaseRequestHandlerParameter<TEntity> where TEntity : BaseEntity
    {
        private readonly IMediator _mediator;
        private readonly IRepository<TEntity> _repository;

        public IMediator Mediator => _mediator;
        public IRepository<TEntity> Repository => _repository;

        public BaseRequestHandlerParameter(IMediator mediator, IRepository<TEntity> repository)
        {
            _mediator = mediator;
            _repository = repository;

        }
    }
}
