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
using Prism.Mvvm;





namespace GRUD_makeS.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();

        }

        protected void OnClosed()
        {
            var viewModel = this.DataContext as IDisposable;
            viewModel?.Dispose();
        }
    }

    class ShellViewModel : IDisposable
    {
        public IDisposable SubViewModel { get; }

        public void Dispose()
        {
            this.SubViewModel.Dispose();

            using (var stream = new System.IO.MemoryStream())
            {
                // hoge hoge
                // もしここでエラーが発生しても必ずDispose
            }
        }
    }
}
     
