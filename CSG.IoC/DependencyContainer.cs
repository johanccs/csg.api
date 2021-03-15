using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces.BaseRepo;
using CSG.Repositories.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace CSG.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<SQLConnType>();
            services.AddSingleton<IBaseRepo<Teacher>, TeacherRepo>();
            services.AddSingleton<IBaseRepo<Student>, StudentRepo>();
            services.AddSingleton<IBaseRepo<ClassEntity>, ClassRepo>();
        }
    }
}
