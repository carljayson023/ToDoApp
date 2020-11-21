using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Controllers
{
    class ItemController
    {
        private readonly DataDbContext _context = new DataDbContext();
        public string AddItem_Class(Itemlist data)
        {

            _context.Itemlists.Add(data);
            _context.SaveChanges();
            return "New Item Successfully Added";
        }
        public string UpdateItem_Class(object data)
        {

            _context.Update(data);
            _context.SaveChanges();
            return "Update Successfully!";
        }

        public string DeleteItem_Class() 
        {
            return "";
        }
    }
}
