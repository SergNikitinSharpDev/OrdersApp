using System.Configuration;
using System.Data.Entity;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using OrdersApp.DataAccess.Interfaces;
using OrdersApp.DataAccess.Services;
using OrdersApp.Domain;
using OrdersApp.Domain.Interfaces;
using OrdersApp.Domain.Services;

namespace OrdersApp.Config
{
    public static class AutofacConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Context
            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", "DefaultConnection")
                .InstancePerLifetimeScope();

            //UoW
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //Repos
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterType<StoredProceduresContainer>().As<IStoredProceduresContainer>().InstancePerDependency();
            
            //Services
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterType<OrderProductService>().As<IOrderProductService>();
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>();


            builder.RegisterType<ShipmentService>().As<IShipmentService>();


            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var context = scope.Resolve<ApplicationDbContext>();
                context.Database.Initialize(true);
            }

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}