using Distributeur.Models;

namespace Distributeur.DAL
{
    public interface IIngredientDAO
    {
        List<Ingredient> GetAll();
        Ingredient Get(string name);
    }
}