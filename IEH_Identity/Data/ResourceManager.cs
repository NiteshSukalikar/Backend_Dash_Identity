using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.Data
{
    internal static class ResourceManager
    {
        public static IEnumerable<ApiResource> Apis()
        {


            return new List<ApiResource>
            {
                new ApiResource {
                    Name = "app.api.whatever",
                    DisplayName = "Whatever Apis",
                    ApiSecrets = { new Secret("a75a559d-1dab-4c65-9bc0-f8e590cb388d".Sha256()) },
                    Scopes = new List<Scope> {
                        new Scope("app.api.whatever.read"),
                        new Scope("app.api.whatever.write"),
                        new Scope("app.api.whatever.full")
                    }
                },
                new ApiResource("app.api.weather","Weather Apis"),
                new ApiResource("app.apii.weather","Weather Apis2")

            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
    {
        new IdentityResources.OpenId()
    };
        }
    }
}
