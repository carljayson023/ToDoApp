using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public interface IDetalistRepository : IDisposable
    {
        IEnumerable<Datalist> GetAllList();
        Datalist GetListByID(int listId);
        void InsertList(Datalist insertList);
        void DeleteList(int listId);
        void UpdateList(Datalist updateList);
        void Save();

    }
}
