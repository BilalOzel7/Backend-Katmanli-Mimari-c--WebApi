using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatmanlıMimari.Core
{
   public interface IBaseRepository<T> where T:class
    {
        List<T> List();
        T Find(int id);
        bool Update(T entity);
        bool Delete(T entity);
        bool Add(T entity);
        DbSet<T> Set();
        void Commit();
    }
}
