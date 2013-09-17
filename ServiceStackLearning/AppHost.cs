using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;

namespace ServiceStackLearning
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Wm. Barrett Simms ServiceStack", typeof(CalculationService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            Routes.AddFromAssembly(typeof(CalculationService).Assembly);
            container.RegisterAutoWiredAs<Calculator, ICalculator>().ReusedWithin(ReuseScope.Container);
            SetConfig(new EndpointHostConfig(){DebugMode = true});
        }
    }
}