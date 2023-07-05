using Classmanagement.Repository.Interfaces;
using Classmanagement.Repository.Repositories;


namespace ClassManagement.Api.Extensions
{
    public static class AddRepositoryConfig
    {
        public static WebApplicationBuilder AddRepoConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
           

            return builder;

        }
    }
}
