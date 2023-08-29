using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Core.ViewModels;
using Mc2.CrudTest.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public CrudDbContext _dbContext { get; }

        public CustomerRepository(CrudDbContext cmsDbContext)
        {
            _dbContext ??= cmsDbContext;
        }


        #region Add Customer
        public async Task Add(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
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

                await _dbContext.Customers.AddAsync(customer, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                
            }
            catch (Exception)
            {
               
                throw;
            }

        }
        #endregion 



        #region Get Customers
        public async Task<List<GetCustomerVm>> GetCustomers(int count, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.Customers.Take(count).Select(s => new GetCustomerVm
                {
                    Id = s.Id,
                    BankAccountNumber = s.BankAccountNumber,
                    DateOfBirth = s.DateOfBirth,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,

                }).AsNoTracking().ToListAsync(cancellationToken);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion 




        #region Edit Customer
        public async Task Edit(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = await FindById(request.Id , cancellationToken);
                if (customer != null)
                {
                    customer.PhoneNumber = request.PhoneNumber;
                    customer.Firstname = request.Firstname;
                    customer.Lastname = request.Lastname;
                    customer.DateOfBirth = request.DateOfBirth;
                    customer.Email = request.Email;
                    customer.BankAccountNumber = request.BankAccountNumber;


                    _dbContext.Customers.Update(customer);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion 




        #region Delete Customer By Id
        public async Task DeleteById(long id, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = await FindById(id, cancellationToken);
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync(cancellationToken);
                
                
            }
            catch (Exception)
            {
               
                throw;
            }
        }
        #endregion 



        #region Find Customer By Id
        private async Task<Customer> FindById(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.FindAsync(id, cancellationToken);
        }
        #endregion 




        #region Get  Customer By Id
        public async Task<GetCustomerVm> GetById(long id, CancellationToken cancellationToken)
        {
            try
            {

                return await _dbContext.Customers.Where(a => a.Id == id).Select(c => new GetCustomerVm
                {

                    BankAccountNumber = c.BankAccountNumber,
                    DateOfBirth = c.DateOfBirth,
                    Email = c.Email,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    PhoneNumber = c.PhoneNumber

                }).SingleOrDefaultAsync(cancellationToken);


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion 






        #region Dispose
        protected bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                _dbContext.Dispose();
            }

            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
