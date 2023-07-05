
using ClassManagement.Api.Extensions;

namespace ClassManagementApi
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

            // database extension
            builder.AddDbConfig();
            // repository config
            builder.AddRepoConfig();

            // add cors config
            var MyAllowAnyOrigin = "_myAllowAnyOrigin";
            builder.AddCorsConfiguration(MyAllowAnyOrigin);

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
            app.UseCors(MyAllowAnyOrigin);
            app.Run();
        }
    }
}