using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Infrastructure.Data.Entities;
using Mc2.CrudTest.Core.Commands.Customer;


namespace Mc2.CrudTest.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public CrudDbContext _crudDbContext { get; }

        public CustomerRepository(CrudDbContext cmsDbContext)
        {
            _crudDbContext = cmsDbContext;
        }


        public async Task<long> Add(AddCustomerCommond request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                BankAccountNumber = request.BankAccountNumber,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            await _crudDbContext.Customers.AddAsync(customer, cancellationToken);

            await _crudDbContext.SaveChangesAsync();

            return customer.Id;

        }





        //public async Task<List<Customer>> GetCustomers(int count)
        //{
        //    return await _crudDbContext.Posts
        //      .Select(x => new Customer
        //      {
        //          Id = x.Id,
        //          //Title = x.Title,
        //          //Content = x.Content,
        //          //CreatedDate = x.CreatedDate
        //      }).OrderByDescending(x => x.CreatedDate)
        //      .Take(count)
        //      .ToListAsync();
        //}


        //public async Task<int> Edit(PostDomain post)
        //{
        //    _cmsDbContext.Update(post);

        //    await _cmsDbContext.SaveChangesAsync();

        //    return post.Id;
        //}


        //public Task<long> Delete(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
