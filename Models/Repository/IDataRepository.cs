using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Models.Repository
{
    public interface IDataRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T dbEntity, T entity);
        void Delete(T entity);
    }
}
