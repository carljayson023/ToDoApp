using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public class DatalistRepository : IDetalistRepository
    {
        private readonly DataDbContext context;

        public DatalistRepository(DataDbContext _context)
        {
            this.context = _context;
        }
        
        public Datalist GetDatalist(int Id) // Find all Id or get by id
        {
            return context.Datalists.Find(Id);
             
            //throw new NotImplementedException();
        }

        public IEnumerable<Datalist> GetAllDatalist() // Get all Data
        {

            return context.Datalists;
            //throw new NotImplementedException();
        }

        public Datalist Add(Datalist datalist) // Add to Datalist table
        {
            context.Datalists.Add(datalist);
            context.SaveChanges();
            return datalist;
            //throw new NotImplementedException();
        }

        public Datalist Update(Datalist datalistChanges)  // Update
        {
            var data_list = context.Datalists.Attach(datalistChanges);
            data_list.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return datalistChanges;
            //throw new NotImplementedException();
        }

        public Datalist Delete(int id) // -------------------> delete datalist
        {
            Datalist _list = context.Datalists.Find(id);
            if (_list != null)
            {
                context.Datalists.Remove(_list);
                context.SaveChanges();
            }
            return _list;
            //throw new NotImplementedException();
        }

        
    }
}
