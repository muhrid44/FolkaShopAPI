using FolkaShopAPI.Helper;
using FolkaShopAPI.Repository;
using FolkaShopAPI.Service;

namespace FolkaShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Setup connection for database
            ApplicationSettings.connectionString = builder.Configuration.GetConnectionString("connstring");

            //Setup dependency injetion
            builder.Services.AddScoped<IShopRepository, ShopRepository>();
            builder.Services.AddScoped<IShopService, ShopService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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