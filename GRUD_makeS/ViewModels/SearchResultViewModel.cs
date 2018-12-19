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
    class SearchResultViewModel 
    {
        public SearchResultViewModel()
        {
            CreateViewModel = new CreateViewModel();
            DataGridViewModel = new DataGridViewModel();
        }

        public CreateViewModel CreateViewModel { get; }
        public DataGridViewModel DataGridViewModel { get; }



    }
}
