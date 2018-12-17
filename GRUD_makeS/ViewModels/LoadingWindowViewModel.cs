using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GRUD_makeS.Models.Data;
using Reactive.Bindings.Binding;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;


namespace GRUD_makeS.ViewModels
{
    class LoadingWindowViewModel :BindableBase
    {



        public LoadingWindowViewModel()
        {

            var productInfoDb = ProductInfoDb.Default;


            var subject1 = productInfoDb.ObserveProperty(x => x.Queue);
            var subject2 = productInfoDb.ObserveProperty(x => x.Execute);

            var subjects = new[] { subject1, subject2 };
            
            subjects.Merge().Select(_ => new[] { productInfoDb.Queue, productInfoDb.Execute })
                .Subscribe(xs =>
                {
                    if (xs[0] != xs[1])
                    {
                        Image = @"C:\Users\shotasuzuki\source\repos\GRUD_makeS\GRUD_makeS\Image\lord.PNG";
                    }
                    else
                    {
                        Image = "";
                    }
                    
                
                });
          


        }

        public string image;

        public string Image
        {
            get =>image;
            set =>SetProperty(ref image,value);
        }

    }
}
