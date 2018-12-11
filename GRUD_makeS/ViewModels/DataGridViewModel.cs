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
                /* lastだとVMがDBを読む方法を知っているのでよくない */
                var added =  e.ProductInfo;
                var vm = new ProductInfoViewModel(added);

                ProductInfoViewModels.Add(vm);

            };

            productInfoDb.RemoveChaged += (s, e) =>
            {
                var removed = e.ProductInfo;
                var removedId = removed.Id;
                var found = ProductInfoViewModels.First(x => x.Id == removedId);
                ProductInfoViewModels.Remove(found);


            };

            productInfoDb.UpdateChaged += (s, e) =>
            {
                var updated = e.ProductInfo;
                var updatedId = updated.Id;
                var found = ProductInfoViewModels.First(x => x.Id == updatedId);
                found.Name = updated.Name;
                found.Category = updated.Category;
                found.Price = updated.Price;

            };


        }
    }
}
