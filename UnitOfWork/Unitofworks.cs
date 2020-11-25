using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.UnitOfWork
{
    public class Unitofworks : IDisposable
    {
        private DataDbContext context ;
        private GenericRepository<Itemlist> itemRepository;

        public Unitofworks(DataDbContext context)
        {
            this.context = context;
        }
        public GenericRepository<Itemlist> ItemRepository
        {
            get
            {

                if (this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<Itemlist>(context);
                }
                return itemRepository;
            }
        }

        ////public GenericRepository<Course> CourseRepository
        ////{
        ////    get
        ////    {

        ////        if (this.courseRepository == null)
        ////        {
        ////            this.courseRepository = new GenericRepository<Course>(context);
        ////        }
        ////        return courseRepository;
        ////    }
        ////}

        public void Save()
        {
            context.SaveChanges();
        }

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
