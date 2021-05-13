using KatmanlıMimari.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatmanlıMimari.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        ProductsContext _db;
        public BaseRepository(ProductsContext  db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Added;
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public bool Delete(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int id)
        {
           return Set().Find(id);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
