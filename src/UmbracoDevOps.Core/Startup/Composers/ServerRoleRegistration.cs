using Umbraco.Core;
using Umbraco.Core.Composing;

namespace UmbracoDevOps.Core.Startup.Composers
{
    public class ServerRoleRegistration : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.SetServerRegistrar(new ServerRoleRegistrar());
        }
    }
}
