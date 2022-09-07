﻿using Distributeur.Models;

namespace Distributeur.DAL
{
    public interface IIngredientDAO
    {
        List<Ingredient> GetAll();
    }
}