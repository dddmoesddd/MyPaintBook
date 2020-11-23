using FrameWork.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PaintBook.Content.Domain.PostAndPostInfo.Model;
using PaintBook.Content.Infrastructure.EF.EntityConfigurations;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace PaintBook.Content.Infrastructure.EF.PostAndPostInfo
{
    public class ContentContext : DbContext,IUnitOfWork
    {
        public DbSet<Post> Posts { get; set; }
        private IDbContextTransaction _currentTransaction;
        private IMediator _mediator;
        public bool HasActiveTransaction => _currentTransaction != null;

        public DbContext Context => throw new NotImplementedException();
        //public ContentContext(DbContextOptions<ContentContext> options) : base(options) { }
        public ContentContext(DbContextOptions<ContentContext> options, IMediator mediator) :
        base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }


    }
}
