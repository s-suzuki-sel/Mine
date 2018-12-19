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

        [Dependency]
        public IUnityContainer Container { get; set; }
        [Dependency]
        public IRegionManager RegionManager { get; set; }


        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.Container.RegisterType<DataGridViewModel>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<object, DataGrid>(nameof(DataGrid));

            this.RegionManager.RequestNavigate("Under1Region", nameof(DataGrid));
        }
    }
}
