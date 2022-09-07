using Distributeur.Models;

namespace Distributeur.DAL
{
    public class IngredientDAO : IIngredientDAO
    {
        public List<Ingredient> GetAll()
        {
            return new List<Ingredient>() { new Ingredient() {
                Id= 1,
                Name = "Café",
                UnitPrice = 1
            },new Ingredient() {
                Id= 2,
                Name = "Sucre",
                UnitPrice = 0.1
            },new Ingredient() {
                Id= 3,
                Name = "Crème",
                UnitPrice = 0.5
            },new Ingredient() {
                Id= 4,
                Name = "Thé",
                UnitPrice = 2
            },new Ingredient() {
                Id= 5,
                Name = "Eau",
                UnitPrice = 0.2
            },new Ingredient() {
                Id= 6,
                Name = "Chocolat",
                UnitPrice = 1
            },new Ingredient() {
                Id= 7,
                Name = "Lait",
                UnitPrice = 0.4
            }
            };
        }
        public Ingredient Get(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }
    }
}