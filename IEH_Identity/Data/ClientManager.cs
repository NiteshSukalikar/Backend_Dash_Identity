using IdentityServer4.Models;
using IEH_Shared.StaticConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.Data
{
    internal static class ClientManager
    {
        public static IEnumerable<Client> Clients()
        {


            return new List<Client>
            {
                    //new Client
                    //{
                    //     ClientName = "Client Application1",
                    //     ClientId = "t8agr5xKt4$3",
                    //     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    //     ClientSecrets = { new Secret("eb300de4-add9-42f4-a3ac-abd3c60f1919".Sha256()) },
                    //     AllowedScopes = new List<string> { "app.api.whatever.read", "app.api.whatever.write" },
                    //     AllowOfflineAccess = true,
                    //     RefreshTokenExpiration=TokenExpiration.Absolute,
                    //     AbsoluteRefreshTokenLifetime = 60 * 5
                    //},
                    new Client
                    {
                         ClientName = "Client Application2",
                         ClientId = SharedConstants.ClientId,//"3X=nNv?Sgu$S",
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                         ClientSecrets = { new Secret(SharedConstants.ClientSecret.Sha256()) },
                         AllowedScopes = { SharedConstants.Scope },
                         AllowOfflineAccess = true,
                         //RefreshTokenExpiration=TokenExpiration.Absolute,
                         //AbsoluteRefreshTokenLifetime = 86400,
                         //AccessTokenLifetime=86400,
                         AbsoluteRefreshTokenLifetime = (86400*60),
                         AccessTokenLifetime=(86400*60),
                    }
                    //,
                    // new Client
                    //{
                    //     ClientName = "Client webapp 2",
                    //     ClientId = "3X=nNv?qqqq",
                    //     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    //     ClientSecrets = { new Secret("1554db43-3015-47a8-a748-55bd76b6af8888".Sha256()) },
                    //     AllowedScopes = { "app.api.weather","app.apii.weather" },
                    //     AllowOfflineAccess = true,
                    //     RefreshTokenExpiration=TokenExpiration.Absolute,
                    //     AbsoluteRefreshTokenLifetime = 60 * 5
                    //}
            };
        }
    }
}
