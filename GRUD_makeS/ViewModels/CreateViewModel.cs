using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using GRUD_makeS.Models.Transactions;
using System.Reactive.Linq;

namespace GRUD_makeS.ViewModels
{
    class CreateViewModel :BindableBase
    {

        public CreateViewModel() 
        {
            Name = "名称";
            Category = "カテゴリ";
            Price = 100;
            ButtonText = "Create";

            ClickCommand = new DelegateCommand(async () =>
            {
                
                var creation = new Creation();
                await creation.Execute(Name, Category, Price);

            });

            ClickSearchCommand = new DelegateCommand(() =>
            {
                var vm = new SearchViewModel();
                var Search = new GRUD_makeS.Views.Search();
                Search.ShowDialog();


            });
            
        }

        private string name;
        private string category;
        private int price;
        private string buttonText;

        public string Name
        {
            get => name;
            /* refはポイントみたいなのを渡して上書きをお願いしている。prismの機能 */
            set => SetProperty(ref name,value);
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

        public string ButtonText
        {
            get => buttonText;
            set => SetProperty(ref buttonText, value);
        }



        public DelegateCommand ClickCommand { get; }
        public DelegateCommand ClickSearchCommand { get; }
    }

    



}
