using SeedSolution.IoC;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SeedSolution.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Setup.ConfigureIoC(MoreIoCConfigurations);
        }
        private void MoreIoCConfigurations(ConfigurationExpression x)
        {
            
        }
    }
}
