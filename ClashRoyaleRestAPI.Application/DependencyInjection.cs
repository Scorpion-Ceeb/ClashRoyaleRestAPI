﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Behaviors;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleRestAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(RequestExceptionHandler<,,>));
            
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

            return services;
        }
    }
}
