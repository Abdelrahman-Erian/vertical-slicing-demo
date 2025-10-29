using MediatR;
using vertical_slicing_demo.Models;
using vertical_slicing_demo.Repositories;

namespace vertical_slicing_demo.Common.BaseHandlers
{
    public abstract class BaseRequestHandler<TRequest, TResponse, TEntity> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TEntity : BaseEntity
    {
        protected readonly IMediator _mediator;
        protected readonly IRepository<TEntity> _repository;

        public BaseRequestHandler(BaseRequestHandlerParameter<TEntity> parameters)
        {
            _mediator = parameters.Mediator;
            _repository = parameters.Repository;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
