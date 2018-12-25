using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Attributes;
using Prism.Unity;
using Prism.Regions;
using Prism;
using Prism.Modularity;
using GRUD_makeS.Views;
using GRUD_makeS.ViewModels;
using Unity.Lifetime;
using Prism.Ioc;

namespace GRUD_makeS
{
    class DataGridModule :IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("Under0Region", typeof(DataGrid));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<DataGridViewModel>();
        }
    }
}
