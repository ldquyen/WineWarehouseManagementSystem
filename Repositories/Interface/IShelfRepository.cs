﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IShelfRepository
    {
        Task<List<Shelf>> GetAllShelf();
        Task<bool> AddShelfQuantity(int? shelfid, int? quantity); 
    }
}
