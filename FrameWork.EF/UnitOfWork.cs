using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrameWork.EF
{
    public class UnitOfWork : DbContext,IUnitOfWork, IDisposable  
      
    {

      
        private readonly DbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
     
        public bool HasActiveTransaction => _currentTransaction != null;

        public DbContext Context
        {
            get { return _context; }
        }

 

        public UnitOfWork(DbContext context)
        {
            _context = context;
     
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction  =await  _context.Database.BeginTransactionAsync();

            return _currentTransaction;
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

        public IExecutionStrategy CreateExecutionStrategy()
        {


            return _context.Database.CreateExecutionStrategy();
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {

                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch(Exception ex)
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

        public  Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //  await _mediator.DispatchDomainEventsAsync(this);
            try
            {
              
                var result =  _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


            return Task.FromResult(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _currentTransaction.Dispose();
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
