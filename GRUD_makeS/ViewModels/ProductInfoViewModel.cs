using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using GRUD_makeS.Models.Data;
using GRUD_makeS.Models.Transactions;



namespace GRUD_makeS.ViewModels
{
    class ProductInfoViewModel : BindableBase
    {

        /* クラスじゃなくてインターフェースでもらいたい。 */
        public ProductInfoViewModel(ProductInfo productInfo)
        {
            this.Id = productInfo.Id;
            this.Name = productInfo.Name;
            this.Category = productInfo.Category;
            this.Price = productInfo.Price;

            this.EditCommand = new DelegateCommand(()=> 
            {
                /*xamlには引数ありでdatacontextをかけないのでコードで書く*/
                var vm = new EditInputViewModel(productInfo);
                var editInput = new GRUD_makeS.Views.EditInput();
                editInput.DataContext=vm;
                editInput.ShowDialog();



            });
            this.DeleteCommand = new DelegateCommand(() => 
            {
                var deleteing = new Deleting();
                deleteing.Execute(Id);

            });


        }

        private string name;
        private string category;
        private int price;
        
        
        public int Id { get; }
        public string Name
        {
            get => name;
            set =>SetProperty(ref name,value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category,value);
        }

        public int Price
        {
            get => price;
            set => SetProperty(ref price,value);
        }

        public DelegateCommand EditCommand { get; }
        public DelegateCommand DeleteCommand { get; }
    }
}
