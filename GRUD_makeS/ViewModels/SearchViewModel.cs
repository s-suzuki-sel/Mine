using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Reactive;
using System.Reactive.Linq;
using Reactive.Bindings.Binding;
using Reactive.Bindings.Extensions;
using Reactive.Bindings;
using GRUD_makeS.Models.Data;
using GRUD_makeS.Models.Transactions;
using GRUD_makeS.Views;

namespace GRUD_makeS.ViewModels
{
    class SearchViewModel :BindableBase
    {
        public SearchViewModel()
        {
            string[] items =  { "Name", "Category", "Price" };

            CombBoxItems = items;

           // Genre = "Category";


            /* 取れてない */
            OkCommand=new DelegateCommand(() =>
            {
                var searcion = new Searcion();
                searcion.Execute(items[int.Parse(Genre)], SearchWord);

                this.CancelCommand.Execute();
            });


            CancelCommand= new DelegateCommand(() =>
            {
                /* AppXaml                        thisで自分を所有しているwindowを探せる */
                var SearchWindow = App.Current.Windows.OfType<Search>().First(x => x.DataContext == this);
                SearchWindow.Close();

            });


        }

        private string genre;
        private string searchWord;
        private string[] combBoxItems;

        public string Genre
        {
            get => genre;
            set => SetProperty(ref genre, value);
        }


        public string SearchWord
        {
            get => searchWord;
            set => SetProperty(ref searchWord, value);

        }



        public string[] CombBoxItems
        {
            get => combBoxItems;
            set => SetProperty(ref combBoxItems, value);
        }


        public DelegateCommand OkCommand { get; }
        public DelegateCommand CancelCommand { get; }

    }
}
