﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Identity.Service
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "8888",
                    Username = "hongjun",
                    Password = "hongjun123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Hongjun You"),
                        new Claim(JwtClaimTypes.GivenName, "Hongjun"),
                        new Claim(JwtClaimTypes.FamilyName, "You"),
                        new Claim(JwtClaimTypes.WebSite, "http://hongjun.com"),
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "api.client",
                    ClientName = "ClientCredentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
            };
    }
}
