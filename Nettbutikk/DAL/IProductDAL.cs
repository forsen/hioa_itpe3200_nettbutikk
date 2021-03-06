﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface IProductDAL
    {
        List<Category> getAllCategories();
        List<Product> getAll();
        List<Product> getResult(string searchstring);
        List<string> getAutoComplete(string term);
        Product findProduct(int id);
        bool updateProduct(int id,Product p);
        Product addProduct(int id, Product p);
        List<SubCategory> getAllSubCategories();
        List<Country> getCountries();
        List<Producer> getProducers();
        bool deleteProduct(int id, int adminid);

    }
}
