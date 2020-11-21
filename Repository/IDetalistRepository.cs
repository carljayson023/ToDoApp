using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public interface IDetalistRepository
    {
        Datalist GetDatalist(int Id);
        IEnumerable<Datalist> GetAllDatalist();
        Datalist Add(Datalist datalist);
        Datalist Update(Datalist datalistChanges);
        Datalist Delete(int id);
    }
}
