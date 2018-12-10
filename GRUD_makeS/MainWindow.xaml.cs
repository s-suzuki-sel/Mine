using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Win32;





namespace GRUD_makeS
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public static ObservableCollection<Person> obc= new ObservableCollection<Person>();
        public static int count = 0;
        private void Create_Click(object sender, RoutedEventArgs e)
        {
                     

            var inputdata = new Person();

            inputdata.ID = count;
            inputdata.Name = NameIn.Text;
            inputdata.Category = CateIn.Text;
            inputdata.Price = int.Parse(PriceIn.Text);

            obc.Add(inputdata);
            // DataGridに設定する
            this.dataGrid.ItemsSource = obc;
            // IDの加算
            count++;
    
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var per = (Person)button.DataContext;

            var i = per.ID;
            var n = per.Name;
            var c = per.Category;
            var p = per.Price;

            GRUD_makeS.EditInput sw = new EditInput(i,n,c,p);
            
            sw.Show();


        }

        public void update(int id, string name, string cate, int pri)
        {

            var inputdata = new Person();
            inputdata.ID = id;
            inputdata.Name = name;
            inputdata.Category = cate;
            inputdata.Price = pri;


            //obc.Insert(id,inputdata);
            obc.RemoveAt(id);
            obc.Insert(id,inputdata);

            this.dataGrid.DataContext = obc;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var per = (Person)button.DataContext;

            
            var i = per.ID;
            obc.RemoveAt(i);
            count--;

            this.dataGrid.DataContext = obc;


        }

    }
}
