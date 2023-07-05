
using ClassManagement.Api.AppContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClassManagement.Api.Extensions
{
    public static class AddDbConfiguration
    {
        public static WebApplicationBuilder AddDbConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            return builder;
        }
    }
    
}
