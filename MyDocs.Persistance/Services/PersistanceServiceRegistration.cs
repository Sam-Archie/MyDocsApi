using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Persistance.Services
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDocsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyDocsConnectionString"),
                b => b.MigrationsAssembly(typeof(MyDocsContext).Assembly.FullName)));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(FoundationRepository<>));

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentReplyRepository, CommentReplyRepository>();
            services.AddScoped<IForumRepository, ForumRepository>();

            return services;
        }
    }
}
