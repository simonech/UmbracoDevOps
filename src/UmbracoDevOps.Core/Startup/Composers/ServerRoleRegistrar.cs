using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Sync;

namespace UmbracoDevOps.Core.Startup.Composers
{
    public class ServerRoleRegistrar : IServerRegistrar
    {
        public IEnumerable<IServerAddress> Registrations => Enumerable.Empty<IServerAddress>();

        public ServerRole GetCurrentServerRole()
        {
            switch (ConfigurationManager.AppSettings["My.Core.LoadBalancing.ServerRole"].ToLowerInvariant())
            {
                case "master":
                    return ServerRole.Master;
                case "replica":
                    return ServerRole.Replica;
                default:
                    return ServerRole.Single;
            }
        }

        public string GetCurrentServerUmbracoApplicationUrl()
        {
            return null;
        }
    }
}
