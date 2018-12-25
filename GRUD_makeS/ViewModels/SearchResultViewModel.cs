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
    class SearchResultViewModel 
    {
        public ReactiveCollection<ProductInfoViewModel> SearchedProductInfoViewModels { get; } = new ReactiveCollection<ProductInfoViewModel>();

        public SearchResultViewModel()
        {
            var productInfoDb = ProductInfoDb.Default;

            productInfoDb.SearchChanged += (s, e) =>
            {
                SearchedProductInfoViewModels.Clear();
                var searched = e.ProductInfo;
                var vm = new ProductInfoViewModel(searched);
                SearchedProductInfoViewModels.Add(vm);

            };


        }


    }
}
