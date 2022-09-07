using Distributeur.Models;

namespace Distributeur.DAL
{
    public class BeverageDAO : IBeverageDAO
    {
        public List<Beverage> GetAll()
        {
            return new List<Beverage>() { new Beverage() {
                Id = 1,
                Name = "Expresso"
            },
            new Beverage() {
                Id = 2,
                Name = "Allongé"
            },
            new Beverage() {
                Id = 3,
                Name = "Capuccino"
            },
            new Beverage() {
                Id = 4,
                Name = "Chocolat"
            },
            new Beverage() {
                Id = 5,
                Name = "Thé"
            }};
        }
        public Beverage Get(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }
    }
}