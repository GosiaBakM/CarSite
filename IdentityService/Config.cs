﻿using Duende.IdentityServer.Models;

namespace IdentityService
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("auctionApp", "Auction App Full Access"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                    {
                        ClientId = "postman",
                        ClientName = "Postman",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = { new Secret("NotASecret".Sha256()) },
                        AllowedScopes = { "openid", "profile", "auctionApp" },
                        RedirectUris = {"https://www.getpostman.com/auth2/callback"}
                    },
                 new Client
                    {
                        ClientId = "nextApp",
                        ClientName = "nextApp",
                        AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                        ClientSecrets = { new Secret("secret".Sha256()) },
                        RequirePkce = false,
                        RedirectUris= {"http://localhost:3000/api/auth/callback/id-server"},
                        AllowOfflineAccess = true,
                        AllowedScopes = { "openid", "profile", "auctionApp" },
                        AccessTokenLifetime = 3600*24*30
                    },
            };
    }
}