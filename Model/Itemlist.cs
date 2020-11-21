using System;

namespace ToDoApp_v1._2.Model
{
    public class Itemlist
    {
        public int ItemlistId { get; set; }
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }

        public int DatalistId { get; set; }
        public virtual Datalist Datalist { get; set; }
    }
}
