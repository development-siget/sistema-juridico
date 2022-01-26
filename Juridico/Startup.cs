using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Net.Http.Headers;
using Juridico.Graph;

namespace Juridico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllersWithViews(); --inicial

            // Configuración de los servicios de autentificación con AAD
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                // <AddSignInSnippet>
                // Specify this is a web app and needs auth code flow
                .AddMicrosoftIdentityWebApp(options =>
                {
                    Configuration.Bind("AzureAd", options);

                    options.Prompt = "select_account";

                    options.Events.OnTokenValidated = async context =>
                    {
                        var tokenAcquisition = context.HttpContext.RequestServices
                             .GetRequiredService<ITokenAcquisition>();

                        var graphClient = new GraphServiceClient(
                            new DelegateAuthenticationProvider(async (request) =>
                            {
                                var token = await tokenAcquisition
                                    .GetAccessTokenForUserAsync(GraphConstants.Scopes, user: context.Principal);
                                request.Headers.Authorization =
                                    new AuthenticationHeaderValue("Bearer", token);
                            })
                        );

                        // Get user information from Graph
                        var user = await graphClient.Me.Request()
                            .Select(u => new
                            {
                                u.Id,
                                u.DisplayName,
                                u.Department,
                                u.Mail,
                                u.UserPrincipalName
                            })
                            .GetAsync();

                        context.Principal.AddUserGraphInfo(user);

                        try
                        {
                            var photo = await graphClient.Me
                                .Photos["48x48"]
                                .Content
                                .Request()
                                .GetAsync();
                            context.Principal.AddUserGraphPhoto(photo);
                        }
                        catch (ServiceException ex)
                        {
                            context.Principal.AddUserGraphPhoto(null);
                        }
                    };

                  
                })
                // </AddSignInSnippet>
                // Add ability to call web API (Graph)
                // and get access tokens
                .EnableTokenAcquisitionToCallDownstreamApi(options =>
                {
                    Configuration.Bind("AzureAd", options);
                }, GraphConstants.Scopes)
                // <AddGraphClientSnippet>
                // Add a GraphServiceClient via dependency injection
                .AddMicrosoftGraph(options =>
                {
                    options.Scopes = string.Join(' ', GraphConstants.Scopes);
                })
                // </AddGraphClientSnippet>
                // Use in-memory token cache
                // See https://github.com/AzureAD/microsoft-identity-web/wiki/token-cache-serialization
                .AddInMemoryTokenCaches();

            // Servicio de solicitudes HTTP
            services.AddHttpClient("sausigetapi", c =>
            {
                c.BaseAddress = new Uri(Configuration["ApiUri"]);
                c.DefaultRequestHeaders.Add("ApiKey", Configuration["ApiKey"]);
            });

            // Servicio de conexión con la base de datos
            /*
            services.AddDbContext<SAUSIGETDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<SAUSIGETDBReadContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SecondConnection")));
            // Servicio de envío de correos
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddHttpContextAccessor();

            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ICasoService, CasoService>();
            */
            //


            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            // Add the Microsoft Identity UI pages for signin/out
            .AddMicrosoftIdentityUI();
            // Políticas de la aplicación
           // services.AddAuthorization(StartupConfigurations.ConfigurePoliciesOptions); //
            // Servicio de AutoMapper
            services.AddAutoMapper(typeof(Startup));
            //
            /*
            var valuesConfig = Configuration.GetSection("ValuesConfiguration").Get<ValuesConfiguration>();
            services.AddSingleton(valuesConfig);
            */
            //
            services.AddRazorPages();
        }
        


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
         {
             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }
             else
             {
                 app.UseExceptionHandler("/Home/Error");
                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                 app.UseHsts();
             }
             app.UseHttpsRedirection();
             app.UseStaticFiles();

            /*
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Configuration["UploadFolder"]),
                RequestPath = new PathString("/files")
            });
            */



            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
                 endpoints.MapRazorPages();
             });
         }
        

       


    }
}
