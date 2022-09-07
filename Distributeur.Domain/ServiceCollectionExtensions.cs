using Distributeur.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Distributeur.Domain
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterDALServices(this IServiceCollection services)
        {
            services.AddScoped<IIngredientDAO, IngredientDAO>();
            services.AddScoped<IBeverageDAO, BeverageDAO>();
            services.AddScoped<IRecipeDAO, RecipeDAO>();
            return services;
        }
    }
}
