using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data
{
    public interface IRepository<T> : IDisposable
    {
        T Insert(T item, bool saveNow);

        T Update(T item, bool saveNow);

        T Delete(T item, bool saveNow);

        int Save();

        IEnumerable<T> Select();
    }
}