﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chart.DAL.Interfaces
{
    public interface IRepository<T> where T: class 
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
    }
}
