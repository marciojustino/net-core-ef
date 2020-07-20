using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using testef.Domain.Repositories;
using testef.Infrastructure.Data;
using testef.Infrastructure.Repositories;

namespace testef.Infrastructure
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"))
                .AddScoped<DataContext, DataContext>()

                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}