using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using profile.Models;
using Npgsql;

namespace profile
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

            //=> services.AddEntityFrameworkNpgsql()
            // .AddDbContext<Storecontext>()
            // .BuildServiceProvider();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<Storecontext>()
                .BuildServiceProvider();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });




            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // connection = @"postgres://zqfcnlmhuauqhp:c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c@ec2-54-221-215-228.compute-1.amazonaws.com:5432/d6bejp4l9a71ps;Database=d6bejp4l9a71ps; User Id=zqfcnlmhuauqhp; Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c; Connection Timeout=30; MultipleActiveResultSets=true";
            //var connection = @"Server=ec2-54-221-215-228.compute-1.amazonaws.com;Database=d6bejp4l9a71ps; User Id=zqfcnlmhuauqhp; Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c; Connection Timeout=30; MultipleActiveResultSets=true ";//Pooling=true;Max Pool Size=100";
            string connString = "User ID=zqfcnlmhuauqhp;Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c;Server=ec2-54-221-215-228.compute-1.amazonaws.com;Database=d6bejp4l9a71ps;Pooling=true;sslmode=Require;TrustServerCertificate=True";

            //var connection = @"Server=localhost;Database=Store; User Id=nanangassa; Password=Lionel88; Connection Timeout=30; MultipleActiveResultSets=true";
            var conn = new NpgsqlConnection(connString);

            services.AddDbContext<Storecontext>(options => options.UseSqlServer(connString));
            //services.AddDbContext<Storecontext>(options => options.UseNpgsql(connString));

            services.AddMvc();

            services.AddMemoryCache();
            services.AddAntiforgery();
            services.AddAuthenticationCore();
            services.AddRouting();

            services.AddSession();
            services.AddAuthentication();
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new MiddlewareFilterAttribute(typeof(LocalizationPipeline)));
            //});
            //services.AddSingleton<RequestLocalizationOptions>();
            //services.AddSingleton<Storecontext>();
            //services.Add(ServiceDescriptor.Singleton<IStartupFilter, MiddlewareFilterBuilderStartupFilter>());
            //services.AddIdentityCore<User>()
            //    .AddEntityFrameworkStores<Storecontext>()
            //    .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              }
              else
              {
                  app.UseExceptionHandler("/Home/Error");
                  app.UseHsts();
              }


            app.UseSession();
            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {

                routes.MapRoute("blog", "blog/{*article}",
           defaults: new { controller = "Blog", action = "Article" });

                routes.MapRoute(


                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
