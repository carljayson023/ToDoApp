using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToDoApp_v1._2.Model;
//using ToDoApp_v1._2.Repository;
using System.Threading.Tasks;
using ToDoApp_v1._2.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp_v1._2.Controllers
{
    //---------------------------------------------------------------------> 
    //-------------------------------------------------------------------------use the UnitOfWork Class and Repositories
    public class ItemController 
    {

        private readonly GenericRepository genericRepository;

        public ItemController(GenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public ViewResult Index()
        {
            var Customers = unitOfWork.CustomerRepository.Get();
            return View(Customers.ToList());
        }
        public IActionResult Index()
        { return }
        // GET: /Customer/Details/5
        public ViewResult Details(int id)
        {
            Customer Customer = unitOfWork.CustomerRepository.GetByID(id);
            return View(Customer);
        }

        public string _GetAllItem()
        {
            var courses = _unitofWork.ItemRepository.Get(includeProperties: "Department");
            return View(courses.ToList());
        }
        public async Task<Itemlist> _AddItem(Itemlist data)
        {
            var add_data = await genericRepository.InsertList(data);
            return 
        }
        //private readonly DataDbContext _context = new DataDbContext();
        //public string AddItem_Class(Itemlist data)
        //{

        //    _context.Itemlists.Add(data);
        //    _context.SaveChanges();
        //    return "New Item Successfully Added";
        //}
        //public string UpdateItem_Class(object data)
        //{

        //    _context.Update(data);
        //    _context.SaveChanges();
        //    return "Update Successfully!";
        //}

        //public string DeleteItem_Class() 
        //{
        //    return "";
        //}
    }
}
