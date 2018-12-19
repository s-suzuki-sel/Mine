using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GRUD_makeS.Models.Data;
using System.Windows.Data;
using System.Reactive;
using System.Reactive.Linq;
using Reactive.Bindings.Binding;
using Reactive.Bindings.Extensions;
using Reactive.Bindings;

namespace GRUD_makeS.ViewModels
{
    class DataGridViewModel
    {   
        public ReactiveCollection<ProductInfoViewModel> ProductInfoViewModels { get; } = new ReactiveCollection<ProductInfoViewModel>();

        public ReactiveCollection<ProductInfoViewModel> SearchedProductInfoViewModels { get; } = new ReactiveCollection<ProductInfoViewModel>();
        public DataGridViewModel()
        {
            var productInfoDb = ProductInfoDb.Default;
            BindingOperations.EnableCollectionSynchronization(this.ProductInfoViewModels, new object());
            
            /* イベントを購読しているが、解除されていない。*/
            /* reactivePropatyというライブラリを使用するとまとめられる */
            /* transactionとの関係 */

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

            /* viewmodel同士の参照が発生していてよくない */
            productInfoDb.UpdateChaged += (s, e) =>
            {
                var updated = e.ProductInfo;
                var updatedId = updated.Id;
                var found = ProductInfoViewModels.First(x => x.Id == updatedId);
                found.Name = updated.Name;
                found.Category = updated.Category;
                found.Price = updated.Price;

            };

            productInfoDb.SearchChanged += (s, e) =>
            {
                /* lastだとVMがDBを読む方法を知っているのでよくない */
                var searched = e.ProductInfo;
                var vm = new ProductInfoViewModel(searched);

                SearchedProductInfoViewModels.Add(vm);

            };


        }
    }
}
