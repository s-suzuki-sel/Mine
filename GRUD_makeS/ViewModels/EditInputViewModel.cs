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
/* 主にReactiveProptyはviewModelで使う */
using System.Reactive;
using System.Reactive.Linq;
using Reactive.Bindings.Binding;
using Reactive.Bindings.Extensions;
using Reactive.Bindings;

namespace GRUD_makeS.ViewModels
{
    class EditInputViewModel 
    {
        

        public EditInputViewModel(ProductInfo productInfo)
        {

            Name = new ReactiveProperty<string>(productInfo.Name);
            Category = new ReactiveProperty<string>(productInfo.Category);
            Price = new ReactiveProperty<string>(productInfo.Price.ToString());





            OkCommand = new[]
            {
                Name.Select(x => !string.IsNullOrEmpty(x)),
                Category.Select(x => !string.IsNullOrEmpty(x)),
                Price.Select(x => int.TryParse(x, out var _))
            }
            .CombineLatestValuesAreAllTrue()
            .ToReactiveCommand();

            OkCommand.Subscribe(() =>
           {
               var updating = new Updating();
               updating.Execute(productInfo.Id, Name.Value, Category.Value, int.Parse(Price.Value));


                /* 動作は同じなのでExcuteでCancelCommandを呼び出す */
               this.CancelCommand.Execute();
           });

            CancelCommand = new ReactiveCommand();

            CancelCommand.Subscribe(() =>
            {
                /* AppXaml                        thisで自分を所有しているwindowを探せる */
                var editWindow = App.Current.Windows.OfType<EditInput>().First(x => x.DataContext == this);
                editWindow.Close();

            });

           

            Name.Subscribe(i => Console.WriteLine(i));

            Category.Subscribe(i => Console.WriteLine(i));
            Price.Subscribe(i => Console.WriteLine(i));

        }



        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<string> Category { get; }
        public ReactiveProperty<string> Price { get; }

        public ReactiveCommand OkCommand { get; }
        public ReactiveCommand CancelCommand { get; }
    }
}
