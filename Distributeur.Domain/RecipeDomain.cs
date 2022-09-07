using Distributeur.DAL;
using Distributeur.Models;

namespace Distributeur.Domain
{
    public class RecipeDomain : IRecipeDomain
    {
        private readonly IRecipeDAO RecipeDAO;
        public RecipeDomain(IRecipeDAO recipeDAO)
        {
            RecipeDAO = recipeDAO;

        }
        /// <summary>
        /// Get the calculated price of a beverage
        /// </summary>
        /// <remarks>
        /// Price = sum of (ingredients unit price * quantity) * 30% margin
        /// </remarks>
        /// <param name="beverageName"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public double GetPrice(string beverageName)
        {
            var recipes = RecipeDAO.GetAll();
            var beverageRecipes = recipes.Where(x =>x.Beverage!=null && x.Beverage.Name.Equals(beverageName));
            if(!beverageRecipes.Any())
            {
                throw new NotFoundException($"{beverageName} was not found in the list of available beverages.");
            }
            //TODO : put the margin in a configuration file
            return Math.Round(beverageRecipes.Sum(x=>x.Ingredient.UnitPrice*x.Quantity)*1.3,2);
        }
    }
}