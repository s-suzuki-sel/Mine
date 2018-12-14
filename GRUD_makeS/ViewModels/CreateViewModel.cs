using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using GRUD_makeS.Models.Transactions;


namespace GRUD_makeS.ViewModels
{
    class CreateViewModel :BindableBase
    {
        


        public CreateViewModel() 
        {
            Name = "鈴木";
            Category = "人";
            Price = 100;
            ClickCommand = new DelegateCommand(async () =>
            {

                var creation = new Creation();
                await creation.Execute(Name, Category, Price);
            });


        }

        private string name;
        private string category;
        private int price;
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




        public DelegateCommand ClickCommand { get; }

    }

    



}
