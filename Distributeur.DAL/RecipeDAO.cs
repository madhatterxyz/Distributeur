using Distributeur.Models;

namespace Distributeur.DAL
{
    public class RecipeDAO : IRecipeDAO
    {
        private readonly IIngredientDAO _ingredientDAO;
        private readonly IBeverageDAO _beverageDAO;
        private List<Recipe> _recipes;
        public RecipeDAO(IIngredientDAO ingredientDAO, IBeverageDAO beverageDAO)
        {
            _ingredientDAO = ingredientDAO;
            _beverageDAO = beverageDAO;
            _recipes = new List<Recipe>() {
                //Expresso
                new Recipe(){ Beverage = _beverageDAO.Get("Expresso"), Quantity=1, Ingredient = _ingredientDAO.Get("Café")},
                new Recipe(){ Beverage = _beverageDAO.Get("Expresso"), Quantity=1, Ingredient = _ingredientDAO.Get("Eau")},
                //Allongé
                new Recipe(){ Beverage = _beverageDAO.Get("Allongé" ),Quantity=1, Ingredient = _ingredientDAO.Get("Café")},
                new Recipe(){ Beverage = _beverageDAO.Get("Allongé" ),Quantity=2, Ingredient = _ingredientDAO.Get("Eau")},
                //Capuccino              
                new Recipe(){ Beverage = _beverageDAO.Get("Capuccino" ),Quantity=1, Ingredient = _ingredientDAO.Get("Café")},
                new Recipe(){ Beverage = _beverageDAO.Get("Capuccino" ),Quantity=1, Ingredient = _ingredientDAO.Get("Chocolat")},
                new Recipe(){ Beverage = _beverageDAO.Get("Capuccino" ),Quantity=1, Ingredient = _ingredientDAO.Get("Eau")},
                new Recipe(){ Beverage = _beverageDAO.Get("Capuccino" ),Quantity=1, Ingredient = _ingredientDAO.Get("Crème")},
                //Chocolat               
                new Recipe(){ Beverage = _beverageDAO.Get("Chocolat" ),Quantity=3, Ingredient = _ingredientDAO.Get("Chocolat")},
                new Recipe(){ Beverage = _beverageDAO.Get("Chocolat" ),Quantity=2, Ingredient = _ingredientDAO.Get("Lait")},
                new Recipe(){ Beverage = _beverageDAO.Get("Chocolat" ),Quantity=1, Ingredient = _ingredientDAO.Get("Eau")},
                new Recipe(){ Beverage = _beverageDAO.Get("Chocolat" ),Quantity=1, Ingredient = _ingredientDAO.Get("Sucre")},
                //Thé                    
                new Recipe(){ Beverage = _beverageDAO.Get("Thé" ),Quantity=1, Ingredient = _ingredientDAO.Get("Thé")},
                new Recipe(){ Beverage = _beverageDAO.Get("Thé" ),Quantity=2, Ingredient = _ingredientDAO.Get("Eau")}
            };
        }
        public List<Recipe> GetAll()
        {
            return _recipes;
        }
        //TODO : next feature
        public Recipe Create(string beverageName, string ingredientName, int ingredientQuantity)
        {
            Beverage beverage = _beverageDAO.Get(beverageName);
            if (beverage == null)
            {
                throw new NotFoundException($"{beverageName} not found in available beverages.");
            }
            Ingredient ingredient = _ingredientDAO.Get(ingredientName);
            if (ingredient == null)
            {
                throw new NotFoundException($"{ingredientName} not found in available ingradients.");
            }
            Recipe recipe = new Recipe() { Beverage = beverage, Ingredient = ingredient, Quantity = ingredientQuantity };
            _recipes.Add(recipe);
            return recipe;
        }
    }
}