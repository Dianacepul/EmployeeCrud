using EmployeeCrud.Data;
using System.Collections.Generic;

namespace EmployeeCrud.Repo
{
    public interface IRepository<T> where T : Employee
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        IEnumerable<T> GetAllActive();

        IEnumerable<T> GetAllNotActive();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}