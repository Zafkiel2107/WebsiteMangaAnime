using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Models.DI
{
    public class NinjectDatabaseModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabase>().To<Storage.Storage>().WithConstructorArgument("storage", new Storage.Storage());
        }
        public void RegisterDependencies()
        {
            StandardKernel kernel = new StandardKernel(this);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}