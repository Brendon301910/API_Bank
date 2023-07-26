using API_bank.Models;
using System.Collections.Generic;

namespace API_bank.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByConta(int conta);
        T Insert(T entity);
        T Update(T entity);
        int Delete(int conta);
    }
}
