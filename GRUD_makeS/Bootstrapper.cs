using Prism.Mvvm;
using Prism;
using Unity;
using Prism.Unity;
using Prism.Regions;
using Prism.Modularity;
using System.Linq;
using System.Windows;
using GRUD_makeS.Views;
using Prism.Logging;

namespace GRUD_makeS
{
    class Bootstrapper : UnityBootstrapper
    {
        /* なんか入ってるコンテナ */
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();

        }

        protected override void InitializeShell()
        {
            ViewModelLocator.SetAutoWireViewModel(this.Shell, true); // ここでViewModelを差し込む
            ((Shell)this.Shell).Show();

        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            var catalog = (ModuleCatalog)this.ModuleCatalog;
            catalog.AddModule(typeof(ImportWindowModule));
            catalog.AddModule(typeof(DataGridModule));
        }
    }

    

}
