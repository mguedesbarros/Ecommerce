using System;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.Interfaces.Validation;
using Ecommerce.Domain.Services;
using Ecommerce.Domain.Validation;
using Ecommerce.Infra.Data.Context;
using Ecommerce.Infra.Data.Context.Interfaces;
using Ecommerce.Infra.Data.Repositories;
using Ecommerce.Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application 
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            // Services
            services.AddScoped<IProdutoService, ProdutoService>();

            //Validation
            //services.AddScoped<IValidation, Validation>();
            services.AddScoped<ValidationResult>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<EcommerceContext>();


        }
    }
}
