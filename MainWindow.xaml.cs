using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataDbContext _context = new DataDbContext();

        private CollectionViewSource datalistViewSource;
        
        public MainWindow()
        {
            InitializeComponent();
            datalistViewSource =
            (CollectionViewSource)FindResource(nameof(datalistViewSource));
        }

        private void GetList()
        {
            _context.Datalists.Load();
            _context.Itemlists.Load();
            // bind to the source
            datalistViewSource.Source =
                _context.Datalists.Local.ToObservableCollection();
           

        }
        private void Window_Loaded(object sender, RoutedEventArgs e) //----------------- > windows load
        {
            _context.Database.EnsureCreated();
            // load the entities into EF Core
            GetList();
            listDataGrid.SelectedItems.Clear();
            
           
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }
        public void OpenListform(object s, RoutedEventArgs e) // open New form to add new List
        {
            
            CreateListForm win2 = new CreateListForm();
            win2.ShowDialog();
            listDataGrid.Items.Refresh();
            itemsDataGrid.Items.Refresh();
            GetList();
            
        }
    
        public void AddItemform(object s, RoutedEventArgs e) // open New form to add new item
        {
            CreateItemForm win3 = new CreateItemForm();
            win3._ItemDataListId = ListDataId;
            win3.ShowDialog();

            listDataGrid.Items.Refresh();
            itemsDataGrid.Items.Refresh();
            GetList();
        }
        
        public void SelectListToEdit(object s, RoutedEventArgs e)
        {
            
            var ListData = (s as FrameworkElement).DataContext as Datalist;
          
            CreateListForm winlist = new CreateListForm();
            winlist._ListId = ListData.DatalistId;
            winlist._ListName = ListData.Name;
            winlist._ListDescription = ListData.Description;

            winlist.ShowDialog();
        }
        
        public void SelectItemToEdit(object s, RoutedEventArgs e)
        {

            var ItemData = (s as FrameworkElement).DataContext as Itemlist;
            
            CreateItemForm winItem = new CreateItemForm();
            winItem._ItemId = ItemData.ItemlistId;
            winItem._ItemNames = ItemData.Name;
            winItem._ItemDetail = ItemData.Detailed;
            winItem._ItemStatuz = ItemData.Status;
            winItem._ItemDataListId = ItemData.DatalistId;
            winItem.ShowDialog();
            

        }
        public void DeleteList(object s, RoutedEventArgs e) // ------------------- DELETE data in List
        {
            var ListToDelete = (s as FrameworkElement).DataContext as Datalist;
            
            _context.Datalists.Remove(ListToDelete);
            _context.SaveChanges();

        }
        
        public void DeleteItem(object s, RoutedEventArgs e) // -------------------> DELETE data in ITem
        {
            var ItemToDelete = (s as FrameworkElement).DataContext as Itemlist;

            _context.Itemlists.Remove(ItemToDelete);
            _context.SaveChanges();
            //MessageBox.Show(ItemToDelete.ItemlistId.ToString());
            MessageBox.Show($" {ItemToDelete.Name } has Successfuly Deleted.");
        }

        //public static int Global_ListData ;
        int ListDataId;
        public void View_ListData(object s, RoutedEventArgs e) // --------------> To View All Item Under the List
        {
            btn_CreateList.Visibility = Visibility.Hidden;
            btn_CreateItem.Visibility = Visibility.Visible;
            btn_BacktoListView.Visibility = Visibility.Visible;

            listDataGrid.Visibility = Visibility.Hidden;
            itemsDataGrid.Visibility = Visibility.Visible;

           
            var ListData = (s as FrameworkElement).DataContext as Datalist;
            ListDataId = ListData.DatalistId; //-------------------------------> ssend id to createItemForm
            //Global_ListData = ListData.DatalistId;
        }
        public void BacktoListView(object s, RoutedEventArgs e) // --------------> back to list View data
        {
             
            btn_CreateList.Visibility = Visibility.Visible;
            btn_CreateItem.Visibility = Visibility.Hidden;
            btn_BacktoListView.Visibility = Visibility.Hidden;

            listDataGrid.Visibility = Visibility.Visible;
            itemsDataGrid.Visibility = Visibility.Hidden;

        }

        public void View_ItemData(object s, RoutedEventArgs e) // View The Detail Of the Item
        {

            /*var ListData = (s as FrameworkElement).DataContext as Itemlist;  
                _context.Datalists.Find(ListData.DatalistId).Name.ToString()   // -------------> example find or Search
            */
        }

    }
}
