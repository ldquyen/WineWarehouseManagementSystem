﻿using BusinessObject.Models;
using DataAccessLayer;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class ProductLineRepostiory : IProductLineRepostiory
    {
        private readonly ProductLineDAO _productLineDAO;

        public ProductLineRepostiory()
        {
            _productLineDAO = ProductLineDAO.instance;
        }
        public async Task CreateProductLine(ProductLine productLine)
        {
            await _productLineDAO.CreateProductLine(productLine);
        }
    }
}