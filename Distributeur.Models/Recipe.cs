namespace Distributeur.Models
{
    public class Recipe
    {
        public int IngredientId { get; set; }
        public int BeverageId { get; set; }
        public int Quantity { get; set; } = 0;
        public Ingredient Ingredient { get; set; }
        public Beverage Beverage { get; set; }
    }
}