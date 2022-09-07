using Distributeur.DAL;
using Distributeur.Domain;
using Distributeur.Models;
using Moq;

namespace Distributeur.Unit.Tests
{
    public class RecipeTests
    {
        [InlineData("Expresso",1.56)]
        [InlineData("Allongé", 1.82)]
        [InlineData("Capuccino",3.51)]
        [InlineData("Chocolat", 5.33)]
        [InlineData("The", 3.12)]
        public void GetPrice_Return_IngredientTimesQuantityPlusMargin(string beverageName,double expectedPrice)
        {
            //Arrange
            var mockRecipeDAO = new Mock<IRecipeDAO>();
            mockRecipeDAO.Setup(x => x.GetAll()).Returns(new List<Recipe>() {
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
            });
            RecipeDomain domain = new RecipeDomain(mockRecipeDAO.Object);

            //Act
            double actualPrice = domain.GetPrice(beverageName);

            //Assert
            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}