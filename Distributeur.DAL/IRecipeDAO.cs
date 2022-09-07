using Distributeur.Models;

namespace Distributeur.DAL
{
    public interface IRecipeDAO
    {
        List<Recipe> GetAll();
    }
}