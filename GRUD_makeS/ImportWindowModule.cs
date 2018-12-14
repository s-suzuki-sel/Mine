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
    public class ImportWindowModule :IModule
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
            this.Container.RegisterType<ImportWindowViewModel>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<object, ImportWindow>(nameof(ImportWindow));

            this.RegionManager.RequestNavigate("UpRegion", nameof(ImportWindow));
        }
    }
}
