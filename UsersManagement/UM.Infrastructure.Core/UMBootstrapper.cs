using Microsoft.Extensions.DependencyInjection;
using UM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using UM.Application.Contracts.Interfaces;
using UM.Domain;
using UM.Infrastructure.EFCore.Repositories;
using UM.Application;

namespace UM.Infrastructure.Core
{
    public class UMBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IRolesApplication, RolesApplication>();
            services.AddTransient<IRolesRepository, RolesRepository>();

            services.AddTransient<IUsersRolesRepository, UsersRolesRepository>();

            //services.AddTransient<ICourseQuery, CourseQuery>();

            services.AddDbContext<UMContext>(options => options.UseSqlServer(connectionstring));
            services.AddTransient<IUnitOfWorkUM, UnitOfWorkUM>();
        }
    }
}
