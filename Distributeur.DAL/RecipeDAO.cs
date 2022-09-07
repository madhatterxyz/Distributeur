using Distributeur.Models;

namespace Distributeur.DAL
{
    public class RecipeDAO : IRecipeDAO
    {
        public List<Recipe> GetAll()
        {
            return new List<Recipe>() {
                //Expresso
                new Recipe(){ BeverageId =1,Quantity=1,IngredientId=1},
                new Recipe(){ BeverageId =1,Quantity=1,IngredientId=5},
                //Allongé
                new Recipe(){ BeverageId =2,Quantity=1,IngredientId=1},
                new Recipe(){ BeverageId =2,Quantity=2,IngredientId=5},
                //Capuccino
                new Recipe(){ BeverageId =3,Quantity=1,IngredientId=1},
                new Recipe(){ BeverageId =3,Quantity=1,IngredientId=6},
                new Recipe(){ BeverageId =3,Quantity=1,IngredientId=5},
                new Recipe(){ BeverageId =3,Quantity=1,IngredientId=3},
                //Chocolat
                new Recipe(){ BeverageId =4,Quantity=3,IngredientId=6},
                new Recipe(){ BeverageId =4,Quantity=2,IngredientId=7},
                new Recipe(){ BeverageId =4,Quantity=1,IngredientId=5},
                new Recipe(){ BeverageId =4,Quantity=1,IngredientId=2},
                //Thé
                new Recipe(){ BeverageId =5,Quantity=1,IngredientId=4},
                new Recipe(){ BeverageId =5,Quantity=2,IngredientId=5}
            };
        }
    }
}