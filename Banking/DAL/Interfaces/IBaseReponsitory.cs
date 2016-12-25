using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DAL.Interfaces
{
    public interface IBaseReponsitory<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T FirstOrDefault(Func<T, bool> func);
        void Save();
    }
}
