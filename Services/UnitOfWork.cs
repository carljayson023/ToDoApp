/*using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Services
{
    class UnitOfWork
    {
        private readonly string _connectionString;

        private readonly List<Datalist> _newList = new List<Datalist>();
        private readonly List<Datalist> _dertyList = new List<Datalist>();
        private readonly List<Datalist> _removedList = new List<Datalist>();
        

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void RegisterNew(Datalist data)
        {
            if (data.DatalistId == 0 && !_newList.Contains(data) && !_dertyList.Contains(data) && !_removedList.Contains(data))
            {
                _newList.Add(data);
            }
        }

        public void RegisterDirty(Datalist data)
        {
            if (data.DatalistId != 0 && !_newList.Contains(data) && !_dertyList.Contains(data) && !_removedList.Contains(data))
            {
                _dertyList.Add(data);
            }
        }

        public void RegisterRemoved(Datalist data)
        {
            bool removedFromNew = _newList.Remove(data);
            if (!removedFromNew)
            {
                _dertyList.Remove(data);
                if (data.DatalistId != 0 && !_removedList.Contains(data))
                {
                    _removedList.Add(data);
                }
            }
        }
        public void Commit()
        {
            using (DataDbContext connection = new DataDbContext(_connectionString))
            {
                InsertNew(connection);
                UpdateDirty(connection);
                DeleteRemoved(connection);
            }
        }

        private void DeleteRemoved(DataDbContext datalist)
        { 

        }
        private void DeleteRemoved(DataDbContext datalist)
        {

        }
    }
}
*/