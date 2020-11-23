using CSharpFunctionalExtensions;
using FluentValidation.AspNetCore;
using FrameWork.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaintBook.Content.Application.MediatRDecorator;
using PaintBook.Content.Application.PostCommandHandler;
using PaintBook.Content.Applicaton.Contracts.Post;
using PaintBook.Content.Domain.PostAndPostInfo.Repository;
using PaintBook.Content.Infrastructure.EF;
using PaintBook.Content.Infrastructure.EF.PostAndPostInfo;
using PaintBook.Content.Infrastructure.EF.PostAndPostInfo.Repository;
using PaintBook.Interface;
using System.Reflection;

namespace PaintBook.Content.Infrastructure.Configuration
{
    public static class Configurator
    {
        public static void Config(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
      
            services.AddDbContextFactory<ContentContext>(options =>
            {
                options.UseSqlServer(CommandsConnectionString.GetConnectionString());
            });
          

            services.AddScoped<PostController>();
            services.AddScoped<ContentContext>();
            services.AddScoped<IPostRepository, PostRepository>();
      //  services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IConnectionString, CommandsConnectionString>();
            var connectionString = CommandsConnectionString.GetConnectionString();
            services.AddSingleton(connectionString);
            services.AddScoped(typeof(IRequestHandler<CreatePostCommand,Result>),typeof( CreatePostCommandHandler));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
       



        }
    }
}
