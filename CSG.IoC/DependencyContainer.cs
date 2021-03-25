using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces;
using CSG.Interfaces.BaseRepo;
using CSG.Repositories.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace CSG.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<SQLConnType>();
            services.AddSingleton<IBaseRepo<Teacher,string>, TeacherRepo>();
            services.AddSingleton<IBaseRepo<Student,string>, StudentRepo>();
            services.AddSingleton<IBaseRepo<ClassEntity,string>, ClassRepo>();
            services.AddSingleton<IBaseRepo<Registration,string>, RegistrationRepo>();
            services.AddSingleton<IUserRepo<User, string>, UserRepo>();
        }
    }
}