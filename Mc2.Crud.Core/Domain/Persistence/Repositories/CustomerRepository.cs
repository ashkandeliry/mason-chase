using GenericRepositoryEntityFramework;
using EShoppingTutorial.Core.Domain.Repositories;
using Mc2.Crud.Core.Entities;

namespace Mc2.Crud.Core.Persistence.Repositories
{
    public class CustomerRepository : Repository<TblCustomer>, ICustomerRepository
    {
        public CustomerRepository(SampleLibraryContext context) : base(context)
        {
            
        }

        public SampleLibraryContext EShoppingTutorialDbContext
        {
            get { return Context as SampleLibraryContext; }
        }

        public override void Add(TblCustomer entity)
        {
            // We can override repository virtual methods in order to customize repository behavior, Template Method Pattern
            // Code here

            base.Add(entity);
        }
    }
}
