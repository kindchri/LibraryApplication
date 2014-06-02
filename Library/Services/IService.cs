using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Repositories;
using Library.Models;

namespace Library.Services
{
    interface IService<T>
    {
        event EventHandler Updated;
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
        T Find(int id);
        T CustomSearch(string searchItem);
        IEnumerable<T> All();
    }
}
