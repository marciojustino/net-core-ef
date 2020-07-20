using Microsoft.Extensions.DependencyInjection;
using testef.Domain.Services;

namespace testef.Domain
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}