//using AspNetCore.Proxy;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Serilog;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HTTP2Relay
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            //        services
//            //.AddHttpClient("eBSEGClient")
//            //.ConfigureHttpClient(config => config.DefaultRequestVersion = new Version(2, 0));

//            //        services.AddProxies();
//            services.AddHttpClient();
//            //services.AddControllers();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            //app.Use(async (context, next) => {
//            //    context.Request.Path = "";
//            //    await next();
//            //});
//            app.UseSerilogRequestLogging();
//            //app.RequestLoggingMiddleware();
//            //app.RunProxy(proxy =>
//            //proxy.UseHttp("https://api.sandbox.push.apple.com:443/3/device/7AB1F8C86C5916CCC914706613173CDECA51F3EE5C352462B4BDD9DF13E96CDA"

//            //));
//            app.UseHTTP2RelayMiddleware();
//            //app.RunProxy(proxy => proxy
//            //    .UseHttp((context, args) =>
//            //        {
//            //            var url = context.Request.Headers["RelayURL"];
//            //            if (url.Count > 0 && !string.IsNullOrEmpty(url[0]))
//            //            {
//            //                return url;
//            //            }


//            //            return "https://api.sandbox.push.apple.com:443/3/device";
//            //        }, builder => builder.WithHttpClientName("eBSEGClient")));
//            //app.UseRouting();

//            //app.UseAuthorization();

//            //app.UseEndpoints(endpoints =>
//            //{
//            //    endpoints.MapControllers();
//            //});
//        }
//    }
//}
