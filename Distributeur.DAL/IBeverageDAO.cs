﻿using Distributeur.Models;

namespace Distributeur.DAL
{
    public interface IBeverageDAO
    {
        List<Beverage> GetAll();
    }
}