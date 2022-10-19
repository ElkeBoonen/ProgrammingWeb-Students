using Eurosong___IMS.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Eurosong___IMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton(typeof(IDataContext), typeof(Database));
            //adjust ConfigureServices-method
            builder.Services.AddControllers();

            builder.Services.AddCors(p => p.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

           // builder.Services.AddCors(s => s.AddPolicy("MyPolicy", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            //ConfigureServices
            builder.Services
              .AddAuthentication()
              .AddScheme<AuthenticationSchemeOptions,
                      BasicAuthenticationHandler>("BasicAuthenticationScheme", options => { });

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("BasicAuthentication",
                        new AuthorizationPolicyBuilder("BasicAuthenticationScheme").RequireAuthenticatedUser().Build());
            });


            var app = builder.Build();
            app.UseCors("MyPolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}