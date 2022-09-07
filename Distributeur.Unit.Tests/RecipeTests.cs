using Distributeur.DAL;
using Distributeur.Domain;
using Distributeur.Models;
using Moq;

namespace Distributeur.Unit.Tests
{
    public class RecipeTests
    {
        [Theory]
        [InlineData("Expresso","1,56")]
        [InlineData("Allongé", "1,82")]
        [InlineData("Capuccino","3,51")]
        [InlineData("Chocolat","5,33")]
        [InlineData("Thé", "3,12")]
        public void GetPrice_Return_IngredientTimesQuantityPlusMargin(string beverageName,string expectedPrice)
        {
            //Arrange
            var mockIngredientDAO = new Mock<IIngredientDAO>();
            mockIngredientDAO.Setup(x => x.Get("Café")).Returns(new Ingredient() { Id = 1, Name = "Café", UnitPrice = 1 });
            mockIngredientDAO.Setup(x => x.Get("Sucre")).Returns(new Ingredient() { Id = 2, Name = "Sucre", UnitPrice = 0.1 });
            mockIngredientDAO.Setup(x => x.Get("Crème")).Returns(new Ingredient() { Id = 3, Name = "Crème", UnitPrice = 0.5 });
            mockIngredientDAO.Setup(x => x.Get("Thé")).Returns(new Ingredient() { Id = 4, Name = "Thé", UnitPrice = 2 });
            mockIngredientDAO.Setup(x => x.Get("Eau")).Returns(new Ingredient() { Id = 5, Name = "Eau", UnitPrice = 0.2 });
            mockIngredientDAO.Setup(x => x.Get("Chocolat")).Returns(new Ingredient() { Id = 6, Name = "Chocolat", UnitPrice = 1 });
            mockIngredientDAO.Setup(x => x.Get("Lait")).Returns(new Ingredient() { Id = 7, Name = "Lait", UnitPrice = 0.4 });

            var mockBeverageDAO = new Mock<IBeverageDAO>();
            mockBeverageDAO.Setup(x => x.Get("Expresso")).Returns( new Beverage() { Id = 1, Name = "Expresso" });
            mockBeverageDAO.Setup(x => x.Get("Allongé")).Returns( new Beverage() { Id = 2, Name = "Allongé"  });
            mockBeverageDAO.Setup(x => x.Get("Capuccino")).Returns( new Beverage() { Id = 3, Name = "Capuccino" });
            mockBeverageDAO.Setup(x => x.Get("Chocolat")).Returns( new Beverage() { Id = 4, Name = "Chocolat" });
            mockBeverageDAO.Setup(x => x.Get("Thé")).Returns( new Beverage() { Id = 5, Name = "Thé" });

            var mockRecipeDAO = new Mock<IRecipeDAO>();
            mockRecipeDAO.Setup(x => x.GetAll()).Returns(new List<Recipe>() {
                //Expresso
                new Recipe(){ BeverageId =1, Beverage = mockBeverageDAO.Object.Get("Expresso"), Quantity=1,IngredientId=1, Ingredient = mockIngredientDAO.Object.Get("Café")},
                new Recipe(){ BeverageId =1,Beverage = mockBeverageDAO.Object.Get("Expresso"),Quantity=1,IngredientId=5, Ingredient = mockIngredientDAO.Object.Get("Eau")},
                //Allongé                              
                new Recipe(){ BeverageId =2,Beverage = mockBeverageDAO.Object.Get("Allongé" ),Quantity=1,IngredientId=1, Ingredient = mockIngredientDAO.Object.Get("Café")},
                new Recipe(){ BeverageId =2,Beverage = mockBeverageDAO.Object.Get("Allongé" ),Quantity=2,IngredientId=5, Ingredient = mockIngredientDAO.Object.Get("Eau")},
                //Capuccino                            
                new Recipe(){ BeverageId =3,Beverage = mockBeverageDAO.Object.Get("Capuccino" ),Quantity=1,IngredientId=1, Ingredient = mockIngredientDAO.Object.Get("Café")},
                new Recipe(){ BeverageId =3,Beverage = mockBeverageDAO.Object.Get("Capuccino" ),Quantity=1,IngredientId=6, Ingredient = mockIngredientDAO.Object.Get("Chocolat")},
                new Recipe(){ BeverageId =3,Beverage = mockBeverageDAO.Object.Get("Capuccino" ),Quantity=1,IngredientId=5, Ingredient = mockIngredientDAO.Object.Get("Eau")},
                new Recipe(){ BeverageId =3,Beverage = mockBeverageDAO.Object.Get("Capuccino" ),Quantity=1,IngredientId=3, Ingredient = mockIngredientDAO.Object.Get("Crème")},
                //Chocolat                            
                new Recipe(){ BeverageId =4,Beverage = mockBeverageDAO.Object.Get("Chocolat" ),Quantity=3,IngredientId=6, Ingredient = mockIngredientDAO.Object.Get("Chocolat")},
                new Recipe(){ BeverageId =4,Beverage = mockBeverageDAO.Object.Get("Chocolat" ),Quantity=2,IngredientId=7, Ingredient = mockIngredientDAO.Object.Get("Lait")},
                new Recipe(){ BeverageId =4,Beverage = mockBeverageDAO.Object.Get("Chocolat" ),Quantity=1,IngredientId=5, Ingredient = mockIngredientDAO.Object.Get("Eau")},
                new Recipe(){ BeverageId =4,Beverage = mockBeverageDAO.Object.Get("Chocolat" ),Quantity=1,IngredientId=2, Ingredient = mockIngredientDAO.Object.Get("Sucre")},
                //Thé                                  
                new Recipe(){ BeverageId =5,Beverage = mockBeverageDAO.Object.Get("Thé" ),Quantity=1,IngredientId=4, Ingredient = mockIngredientDAO.Object.Get("Thé")},
                new Recipe(){ BeverageId =5,Beverage = mockBeverageDAO.Object.Get("Thé" ),Quantity=2,IngredientId=5, Ingredient = mockIngredientDAO.Object.Get("Eau")}
            });
            RecipeDomain domain = new RecipeDomain(mockRecipeDAO.Object);

            //Act
            double actualPrice = domain.GetPrice(beverageName);

            //Assert
            Assert.Equal(expectedPrice, actualPrice.ToString());
        }
    }
}