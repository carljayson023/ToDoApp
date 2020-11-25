using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public class DatalistRepository : IDetalistRepository, IDisposable
    {
        private DataDbContext context;

        public DatalistRepository(DataDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Datalist> GetAllList() // ----------- get all list
        {
            return context.Datalists.ToList();
            //throw new NotImplementedException();

        }
        public Datalist GetListByID(int listId)  //------------ get by id
        {
            return context.Datalists.Find(listId);
            //throw new NotImplementedException();
        }
        public void InsertList(Datalist insertList)
        {
            context.Datalists.Add(insertList);
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




    }
}
