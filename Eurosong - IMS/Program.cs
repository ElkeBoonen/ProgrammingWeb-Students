using Eurosong___IMS.Data;

namespace Eurosong___IMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(s => s.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin()
                                               .AllowAnyMethod()
                                               .AllowAnyHeader()));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton(typeof(IDataContext), new DataBase());
            //builder.Services.AddSingleton(typeof(IDataContext), typeof(DataList);


            var app = builder.Build();
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}