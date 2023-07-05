namespace ClassManagement.Api.Extensions
{
    public static class AddCorsConfig
    {
        public static WebApplicationBuilder AddCorsConfiguration(this WebApplicationBuilder builder, string originName)
        {
            // cors

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    originName, policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
            });

            return builder;
        }
    }
}
