using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Authentication;
using OrderManagement.DataAccess;
using OrderManagement.Entities;
using System.Text;

namespace OrderManagement
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
           
            services.AddMvc();
            services.AddControllers();
           
            /*Start Adding Connection String here*/
            var connectionString = Configuration.GetConnectionString("connStr");
            services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(connectionString));
            //services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(connectionString));
            /*End of Adding Connection string section*/

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddUserStore<ApplicationDBContext>()
                .AddDefaultTokenProviders();

 

            // implement cors policy 
            services.AddCors(o => o.AddPolicy("CorsPolicy", config =>
       {
           config.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .SetIsOriginAllowed(origin => true);

       }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();


            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }


}
