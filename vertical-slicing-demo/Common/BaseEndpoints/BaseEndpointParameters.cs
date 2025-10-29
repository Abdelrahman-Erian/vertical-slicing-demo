﻿using FluentValidation;
using MediatR;

namespace vertical_slicing_demo.Common.BaseEndpoints
{
    public class BaseEndpointParameters<TRequest>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TRequest> _validator;
        public IMediator Mediator => _mediator;
        public IValidator<TRequest> Validator => _validator;
        public BaseEndpointParameters(IMediator mediator, IValidator<TRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }
    }
}
