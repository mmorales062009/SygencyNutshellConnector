
using System.Net;

namespace SygencyNutshellConnector
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

            var app = builder.Build();

            builder.WebHost.ConfigureKestrel(opts =>
            {
                opts.Listen(IPAddress.Loopback, port: 80); // listen on http://localhost:5002
                opts.ListenAnyIP(80); // listen on http://*:5003
                opts.ListenLocalhost(80, listenOptions => listenOptions.UseHttps());  // listen on https://localhost:5004
      
            });
            app.UseSwagger();
                app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
