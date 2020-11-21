using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Controllers;

namespace ToDoApp_v1._2
{
    /// <summary>
    /// Interaction logic for CreateListForm.xaml
    /// </summary>
    
    public partial class CreateListForm : Window
    {
        public int _ListId { get; set; }
        public string _ListName { get; set; }
        public string _ListDescription { get; set; }

        private readonly DataDbContext _context = new DataDbContext();
        Datalist Newlist = new Datalist();
        //----->> Class And Object
        ListController _listController = new ListController(); // Call and Set Controller for ADD UPDATE DELETE 
        public CreateListForm()
        {
            InitializeComponent();
            NewListGrid.DataContext = Newlist;
        }
        private void Cancel(object s, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AddList(object s, RoutedEventArgs e)
        {
            //MessageBox.Show(_ListId.ToString());
            if (ListDescription.Text.Trim() != "" && ListName.Text.Trim() != "")
            {
                if (_ListId != 0) 
                {
                    var updateDataList = new Datalist
                    {
                        DatalistId = _ListId,
                        Name = ListName.Text,
                        Description = ListDescription.Text
                    };

                    //MessageBox.Show(_listController.UpdateList_Class(updateDataList)); // Update Data by Manual
                    
                }
                else
                {
                    //MessageBox.Show(_listController.AddList_Class(Newlist)); // Add Data by Binding

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Fill Up All Boxes!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListName.Text = _ListName;
            ListDescription.Text = _ListDescription;
        }
    }
}
    