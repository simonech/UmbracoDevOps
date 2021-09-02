using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace UmbracoDevOps.Core.Startup.Composers
{
    public class ApplicationInsightsConfiguration : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var AiEnabled = ConfigurationManager.AppSettings["My.Azure.AI.Enabled"].InvariantEquals("true");
            var AiInstrumentationConnectionString = ConfigurationManager.AppSettings["My.Azure.AI.InstrumentationConnectionString"];
            if (!AiEnabled)
            {
                Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.DisableTelemetry = true;
                return;
            }

            Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.ConnectionString = AiInstrumentationConnectionString;
        }
    }
}
