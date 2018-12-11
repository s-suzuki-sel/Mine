using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using GRUD_makeS.Models.Data;
using GRUD_makeS.Models.Transactions;
using GRUD_makeS.Views;


namespace GRUD_makeS.ViewModels
{
    class EditInputViewModel :BindableBase
    {
        

        public EditInputViewModel(ProductInfo productInfo)
        {
            Name = productInfo.Name;
            Category = productInfo.Category;
            Price = productInfo.Price;

            OkCommand = new DelegateCommand(() =>
            {
                var updating = new Updating();
                updating.Execute(productInfo.Id, Name, Category, Price);


                /* 動作は同じなのでExcuteでCancelCommandを呼び出す */
                this.CancelCommand.Execute();
            });

            CancelCommand = new DelegateCommand(() =>
            {
                /* AppXaml                        thisで自分を所有しているwindowを探せる */
                var editWindow = App.Current.Windows.OfType<EditInput>().First(x => x.DataContext == this);
                editWindow.Close();
            });

        }

        private string name;
        private string category;
        private int price;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }



        public DelegateCommand OkCommand { get; }
        public DelegateCommand CancelCommand { get; }
    }
}
