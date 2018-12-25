using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism.Unity.Ioc;
using GRUD_makeS.Views;

namespace GRUD_makeS
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
 
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<ImportWindowModule>();
            moduleCatalog.AddModule<DataGridModule>();
            moduleCatalog.AddModule<LoadingWindowModule>();
            moduleCatalog.AddModule<SearchWindowModele>();
        }

        protected override Window CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        protected override void OnInitialized()
        {
            
        }
    }
}
