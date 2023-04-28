using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using NLog.Web;
namespace EFMysql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Logging.AddNLog("Configs/Nlog.config");
            builder.Services.AddDbContext<ParameterContext>(opt => {
                string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                opt.UseMySql(connectionString, serverVersion);
                
            });
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            //test
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