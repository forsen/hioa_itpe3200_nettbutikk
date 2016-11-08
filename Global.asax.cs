using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Nettbutikk.Models;

namespace Nettbutikk
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer<DatabaseContext>(new DbInitializer());

            using (var db = new DatabaseContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
}
