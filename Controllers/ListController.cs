//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;
//using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Controllers
{
    //---------------------------------------------------------- > Creating the ListController to Repository
    public class ListController 
    {
        private readonly IDetalistRepository _ListRepository;

        public ListController()
        {
            this._ListRepository = new DatalistRepository(new DataDbContext());
        }
        public ListController(IDetalistRepository listRepository)
        {
            this._ListRepository = listRepository;
        }

        public string _GetAllList() //----------------------- get all list
        {
            //var students = from s in _ListRepository.GetAllList() select s;
            return _ListRepository.GetAllList().ToString();
        }
        public Datalist GetList(int id) // -------------------------- get list by id
        {
            Datalist data = _ListRepository.GetListByID(id);
            return data;
        }
        public string AddList(Datalist data) //---------- Add
        {
            _ListRepository.InsertList(data);
            _ListRepository.Save();
            //return _GetAllList();
            return "New List Added!";
        }

        public string UpdateList(Datalist data) //---------------- update
        {
            _ListRepository.UpdateList(data);
            _ListRepository.Save();
            //return _GetAllList();
            return "New List Updated!";
        }
        public string DeleteList(int id) //---------------- Delete
        {
            _ListRepository.DeleteList(id);
            _ListRepository.Save();
            //return _GetAllList();
            return "New List Updated!";
        }
        //private readonly IDetalistRepository _ListRepository;

        //public IEnumerable<string> _GetAllList()
        //{
        //    //return List < _ListRepository > = new DatalistRepository(new Model.DataDbContext); ;
        //    return _ListRepository.GetAllDatalist();
        //    //return new string[] { "value","value"};
        //    //return List<> _GetAllList();
        //}


        //public ListController(IDetalistRepository detalistRepository)
        //{
        //    _ListRepository = detalistRepository;

        //}
        //public List<Datalist> GetAllList()
        //{

        //    //List< DatalistRepository> Data = new List<DatalistRepository>();
        //    //var data = _ListRepository.GetAllDatalist();
        //    //List<DatalistRepository> data2 = new List<DatalistRepository>(_ListRepository.GetAllDatalist); 

        //    if (_ListRepository.GetAllDatalist() == null)
        //    {
        //        return _ListRepository.GetAllDatalist().ToList();
        //    }
        //    else {
        //        return _ListRepository.GetAllDatalist().ToList();
        //    }

        //    //return data;
        //}
        //public ListController()
        //{
        //    _ListRepository = new DatalistRepository(new Model.DataDbContext);

        //}

        //public ListController(IDetalistRepository detalistRepository)
        //{
        //    _ListRepository = detalistRepository;

        //}

        //public ActionResult Index()
        //{

        //    return _ListRepository.GetAllDatalist();
        //}
        //-----------------------------------------------------------------------------
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
