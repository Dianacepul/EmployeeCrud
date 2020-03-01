using EmployeeCrud.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeCrud.Repo
{
    public class Repository<T> : IRepository<T> where T : Employee
    {
        private readonly EmployeeContext context;
        private DbSet<T> entities;

        public Repository(EmployeeContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAllActive()
        {
            return entities.Where(e => e.IsActive == true).AsEnumerable();
        }

        public IEnumerable<T> GetAllNotActive()
        {
            return entities.Where(e => e.IsActive == false).AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Tušti duomenys");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Tušti duomenys");
            }

            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Nėra duomenų");
            }
            context.SaveChanges();
        }
    }
}