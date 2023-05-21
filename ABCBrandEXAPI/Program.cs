using ABCBrandEXAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ABCBrandEXAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => // Adding CORS to the builder
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowAnyOrigin();
                    });
            });

            // Add services to the container.
            builder.Services.AddDbContext<AbContext>(options => //specifiying the database in use
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSQLConn"));
            });
            builder.Services.AddControllers();  //Adding controllers
            builder.Services.AddEndpointsApiExplorer(); //
            builder.Services.AddSwaggerGen();  // using swagger UI

            var app = builder.Build();

            app.UseSwagger(); // using swagger UI
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}