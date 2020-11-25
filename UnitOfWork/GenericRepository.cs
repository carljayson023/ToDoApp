using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.UnitOfWork
{
    public class GenericRepository
    {
        private DataDbContext context;

        public GenericRepository(DataDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Itemlist> GetAllList() // ----------- get all list
        {
            return context.Itemlists.ToList();
            //throw new NotImplementedException();

        }
        public Itemlist GetListByID(int listId)  //------------ get by id
        {
            return context.Itemlists.Find(listId);
            //throw new NotImplementedException();
        }
        public void InsertList(Itemlist insertList) // ------------ Add
        {
            context.Itemlists.Add(insertList);
            //throw new NotImplementedException();
        }
        public void DeleteList(int listId)  // --------------- delete data
        {
            Datalist data = context.Datalists.Find(listId);
            context.Datalists.Remove(data);
            //throw new NotImplementedException();
        }
        public void UpdateList(Datalist updateList) // ----------------update
        {
            context.Entry(updateList).State = EntityState.Modified;
            //throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
            //throw new NotImplementedException();
        }
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        //-----------------------------------------------------------------Implement a Generic Repository and a Unit of Work Class
        /*internal DataDbContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DataDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        //--------------
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }*/

    }
}
