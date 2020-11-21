using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Controllers
{
    public class ListController 
    {
        private readonly IDetalistRepository _ListRepository;

        //public ListController(IDetalistRepository detalistRepository)
        //{
        //    _ListRepository = detalistRepository;

        //}

        //public ListController()
        //{
        //    _ListRepository = new DatalistRepository(new Model.DataDbContext);

        //}

        public ListController(IDetalistRepository detalistRepository)
        {
            _ListRepository = detalistRepository;
        }

        //public ActionResult Index()
        //{

        //    return _ListRepository.GetAllDatalist();
        //}

        //private readonly DataDbContext _context = new DataDbContext();
        //public string AddList_Class(Datalist data)
        //{
        //    _context.Datalists.Add(data);
        //    //_context.Datalists.Find("");
        //    _context.SaveChanges();
        //    return "New Data Successfully Added!!";
        //}
        //public string UpdateList_Class(object data)
        //{
        //    _context.Update(data);
        //    _context.SaveChanges();
        //    return "Data Updated Successfully!";

        //}

        //public string DeleteList_Class()
        //{
        //    return "";
        //}
    }
}
