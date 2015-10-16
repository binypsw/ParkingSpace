using Autofac;
using Autofac.Integration.Mvc;
using ParkingSpace.Services;
using ParkingSpace.Web.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ParkingSpace.Web {
  public class MvcApplication : System.Web.HttpApplication {
    protected void Application_Start() {
      registerAutofac();

      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    private void registerAutofac() {
      var builder = new ContainerBuilder();
      builder.RegisterControllers(typeof(MvcApplication).Assembly);
      builder.RegisterType<App>();
      builder.RegisterType<PDFParkingTicketPrinter>()
          .As<IParkingTicketPrinter>();

      var contianer = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(contianer));
    }
  }
}
