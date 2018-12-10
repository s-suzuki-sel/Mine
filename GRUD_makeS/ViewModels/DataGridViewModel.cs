using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GRUD_makeS.Models.Data;



namespace GRUD_makeS.ViewModels
{
    class DataGridViewModel
    {
        public ObservableCollection<ProductInfoViewModel> ProductInfoViewModels { get; } = new ObservableCollection<ProductInfoViewModel>();

        public DataGridViewModel()
        {
            var productInfoDb = ProductInfoDb.Default;

            productInfoDb.AddChaged += (s, e) =>
            {
                var added =  productInfoDb.ProductInfos.Last();
                var vm = new ProductInfoViewModel(added);

                ProductInfoViewModels.Add(vm);

            };



        }
    }
}
