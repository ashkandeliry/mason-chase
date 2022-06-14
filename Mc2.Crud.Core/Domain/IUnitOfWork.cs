using EShoppingTutorial.Core.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
namespace Mc2.Crud.Core.Domain
{
    public interface IUnitOfWork
    {
        ICustomerRepository customerRepository{ get; }

        Task<int> CompleteAsync();

        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
