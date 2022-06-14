using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.Crud.Core.Domain;
using Mc2.Crud.Core.Entities;
using EShoppingTutorial.Core.Domain.Repositories;
using Mc2.Crud.Core.Persistence.Repositories;

namespace Mc2.Crud.Core.Persistence
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly SampleLibraryContext _context;

        public ICustomerRepository customerRepository{ get; private set; }


        public UnitOfWork(SampleLibraryContext context)
        {
            _context = context;

            customerRepository = new CustomerRepository(_context);
        }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }


        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// No matter an exception has been raised or not, this method always will dispose the DbContext 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
