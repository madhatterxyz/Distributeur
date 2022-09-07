using Distributeur.DAL;

namespace Distributeur.Domain
{
    public class RecipeDomain
    {
        private readonly IRecipeDAO RecipeDAO;
        public RecipeDomain(IRecipeDAO recipeDAO)
        {
            RecipeDAO = recipeDAO;

        }
        public double GetPrice(string beverageName)
        {
            var recipes = RecipeDAO.GetAll();
            var beverageRecipes = recipes.Where(x => x.Beverage.Name.Equals(beverageName));
            return beverageRecipes.Sum(x=>x.Ingredient.UnitPrice)*1.3;
        }
    }
}