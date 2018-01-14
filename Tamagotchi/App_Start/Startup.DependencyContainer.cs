using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Tamagotchi.Domein.Repository;
using Tamagotchi.Controllers;
using Tamagotchi.Models;

namespace Tamagotchi
{
    public partial class Startup
    {
        public void ConfigureDependencyContainer()
        {
            // Autofac setup
            var builder = new ContainerBuilder();

            // Register MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register application dependencies
            builder.RegisterType<TamagotchiEntities>();
            builder.RegisterType<TamagotchiController>();
            builder.RegisterType<HotelroomController>();
            builder.RegisterType<BookingController>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}