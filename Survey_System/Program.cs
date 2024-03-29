using Microsoft.EntityFrameworkCore;
using Survey_System.Data;
using System.Text.Json.Serialization;
namespace Survey_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddEndpointsApiExplorer();
            #region CORS setting for API
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyMethod();
                }

                );
            });
            #endregion
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("_myAllowSpecificOrigins");

            app.Run();
        }
    }
}
