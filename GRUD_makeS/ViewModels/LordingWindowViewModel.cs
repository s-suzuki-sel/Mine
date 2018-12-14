using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace GRUD_makeS.ViewModels
{
    class LordingWindowViewModel :BindableBase
    {
        public LordingWindowViewModel()
        {
           // Image = @"C:\Users\shotasuzuki\source\repos\GRUD_makeS\GRUD_makeS\Image\Lording.jpg";

            var lordingEventer = new LoadingEventer();


            lordingEventer.DataLorded += (s, e) =>
            {
                Image = e.ImagePath;
            };




        }

        public string image;

        public string Image
        {
            get =>image;
            set =>SetProperty(ref image,value);
        }

    }
}
