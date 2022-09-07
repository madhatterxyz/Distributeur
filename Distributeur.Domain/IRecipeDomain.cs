using Distributeur.DAL;

namespace Distributeur.Domain
{
    public interface IRecipeDomain
    {
        double GetPrice(string beverageName);
    }
}