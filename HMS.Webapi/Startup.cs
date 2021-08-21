using HMS.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace HMS.Webapi
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                              "http://webapplication121-dev.us-east-2.elasticbeanstalk.com")
                              .AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                    });
            });
            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            var connectionSettings  = Configuration.GetSection("ConnectionSettings").Get<ConnectionSettings>();
            var aws = Configuration.GetSection("AWS").Get<AWS>();
            var documents = Configuration.GetSection("Documents").Get<Documents>();
            

            services.AddScoped<ActionFilter>();

            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IDishService, DishService>();
            services.AddSingleton<IUserConfigService, UserConfigService>();
            services.AddSingleton<IAdminService, AdminService>();
            services.AddSingleton<IDishCategoryService, DishCategoryService>();
            services.AddSingleton<IMasterService, MasterService>();
            services.AddSingleton<IUserFeedbackService, UserFeedbackService>();
            services.AddSingleton<IBusinessCategoryService, BusinessCategoryService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserAuthService, UserAuthService>();
         
            services.AddSingleton<IHotelService, HotelService>();
            services.AddSingleton<IDbHelper, DbHelper>();
            services.AddSingleton<IImageService, ImageService>();

            services.AddSingleton<ConnectionSettings>(connectionSettings);
            services.AddSingleton<AWS>(aws);
            services.AddSingleton<Documents>(documents);
            


            services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new BadRequestObjectResult(context.ModelState);

            // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
            result.ContentTypes.Add(MediaTypeNames.Application.Json);
            result.ContentTypes.Add(MediaTypeNames.Application.Xml);

            return result;
        };
    });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
                //  app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error-local-development");
               // app.UseExceptionHandler("/error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
