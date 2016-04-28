using System;
using System.Collections.Generic;

namespace Project.Data.IRepositories
{
    public interface IRepository<T> : IDisposable
    {
        T Insert(T item, bool saveNow);

        T Update(T item, bool saveNow);

        T Delete(T item, bool saveNow);

        int Save();

        IEnumerable<T> DeleteRange(IEnumerable<T> items, bool saveNow);

        IEnumerable<T> InsertRange(IEnumerable<T> items, bool saveNow);

        IEnumerable<T> Select();
    }
}