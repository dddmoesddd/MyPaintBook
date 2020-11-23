using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FrameWork.EF
{
    public class DbContextFactory<TContext>
           : IDesignTimeDbContextFactory< TContext> where TContext : DbContext
    {
        private readonly IServiceProvider provider;

        public DbContextFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }


        public TContext CreateDbContext(string[] args)
        {
            if (provider == null)
            {
                throw new InvalidOperationException(
                    $"You must configure an instance of IServiceProvider");
            }

            return ActivatorUtilities.CreateInstance<TContext>(provider);
        }
    }
}
