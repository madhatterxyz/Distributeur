namespace Distributeur.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
