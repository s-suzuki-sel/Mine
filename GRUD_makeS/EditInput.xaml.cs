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
    /// EditInput.xaml の相互作用ロジック
    /// </summary>
    public partial class EditInput : Window 
    {
        int id_temp = 0;

        public EditInput(int id,string name ,string cate,int pri)
        {
            InitializeComponent();            
            id_temp = id;
            SNameIn.Text = name;
            SCateIn.Text = cate;
            SPriceIn.Text = pri.ToString();

            

        }
        public ObservableCollection<Person> Scorection = new ObservableCollection<Person>();


        public void OK_Click(object sender, RoutedEventArgs e)
        {
            
            GRUD_makeS.MainWindow mw = new MainWindow();
                mw.update(id_temp, SNameIn.Text, SCateIn.Text, int.Parse(SPriceIn.Text));

            /*
            var person = new Person();
            var mw = new MainWindow();

            person.Name = SNameIn.Text;
            person.Category = SCateIn.Text;
            person.Price = int.Parse(SPriceIn.Text);

            Scorection.Add(person);
            mw.dataGrid.ItemsSource = Scorection;
            
            */
            Close();


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
