﻿//This OIDC server uses the excellent OpenID Connect/OAuth2 server framework for ASP.NET Core
//called "AspNet.Security.OpenIdConnect.Server" (https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server)
//This is only a proof-of-concept where 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AspNet.Security.OAuth;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Kramerica.BankID.OIDCServer.Providers;
using Kramerica.BankID.Authentication;
using Kramerica.BankID.Authentication.Helpers;
using Kramerica.BankID.Authentication.Extensions;


namespace Kramerica.BankID.OIDCServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<BankIDClient>(client =>
                {
                    client.BaseAddress = new Uri("https://appapi2.test.bankid.com/rp/v5/");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                .ConfigurePrimaryHttpMessageHandler(h => 
                {
                    var handler = new HttpClientHandler();
                    handler.ClientCertificates.Add(Certificates.DownloadBankIDTestCertificate());
                    return handler;
                });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "ServerCookie";
            })
            
            .AddCookie("ServerCookie", options =>
            {
                options.Cookie.Name = CookieAuthenticationDefaults.CookiePrefix + "ServerCookie";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = new PathString("/signin");
                options.LogoutPath = new PathString("/signout");
            })

            .AddBankIDAuthentication(options=> {
                options.CollectIntervalInMilliseconds = 2000;
                options.CollectTimeoutInMilliseconds=30000;
            })

            .AddOAuthValidation()

            .AddOpenIdConnectServer(options =>
            {
                options.ProviderType = typeof(AuthorizationProvider);

                // Enable the authorization, logout, token and userinfo endpoints.
                options.AuthorizationEndpointPath = "/connect/authorize";
                options.LogoutEndpointPath = "/connect/logout";
                options.TokenEndpointPath = "/connect/token";
                options.UserinfoEndpointPath = "/connect/userinfo";
                options.ConfigurationEndpointPath = "/oidc/.well-known/openid-configuration";

                // Note: see AuthorizationController.cs for more
                // information concerning ApplicationCanDisplayErrors.
                options.ApplicationCanDisplayErrors = true;
                options.AllowInsecureHttp = true;

                // Note: to override the default access token format and use JWT, assign AccessTokenHandler:
                //
                // options.AccessTokenHandler = new JwtSecurityTokenHandler
                // {
                //     InboundClaimTypeMap = new Dictionary<string, string>(),
                //     OutboundClaimTypeMap = new Dictionary<string, string>()
                // };
                //
                // Note: when using JWT as the access token format, you have to register a signing key.
                //
                // You can register a new ephemeral key, that is discarded when the application shuts down.
                // Tokens signed using this key are automatically invalidated and thus this method
                // should only be used during development:
                //
                //options.SigningCredentials.AddEphemeralKey();
                //
                // On production, using a X.509 certificate stored in the machine store is recommended.
                // You can generate a self-signed certificate using Pluralsight's self-cert utility:
                // https://s3.amazonaws.com/pluralsight-free/keith-brown/samples/SelfCert.zip
                //
                // options.SigningCredentials.AddCertificate("7D2A741FE34CC2C7369237A5F2078988E17A6A75");
                //
                // Alternatively, you can also store the certificate as an embedded .pfx resource
                // directly in this assembly or in a file published alongside this project:
                //
                // options.SigningCredentials.AddCertificate(
                //     assembly: typeof(Startup).GetTypeInfo().Assembly,
                //     resource: "Mvc.Server.Certificate.pfx",
                //     password: "Owin.Security.OpenIdConnect.Server");
            });
            services.AddScoped<AuthorizationProvider>();
                        services.AddMvc();

                        services.AddDistributedMemoryCache();
            
               }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseWelcomePage();
        }
    }
}