
using IRepository;
using IService;
using Repository;
using Service;

namespace MyBlog
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustom(this IServiceCollection services)
        {
            services.AddScoped<IBlogNewsRepository, BlogNewsRepository>();
            services.AddScoped<IBlogNewsService,BlogNewsService>();
            services.AddScoped<IWriteInfoRepository, WriteInfoRepository>();
            services.AddScoped<IWriteInfoService, WriteInfoService>();
            services.AddScoped<ITypeInfoRepository, TypeInfoRepository>(); 
            services.AddScoped<ITypeInfoService, TypeInfoService>();
            return services;
        }
    }
}