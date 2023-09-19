using API.Database.Repository.Interfaces;
using API.Models;

namespace API.Database.Repository
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly CustomerContext _customerContext;

    public CustomerRepository(CustomerContext customerContext)
    {
      _customerContext = customerContext;
    }

    public Customer? GetCustomerById(int id)
    {
      return _customerContext.Customers.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
      return _customerContext.Customers.ToList();
    }

    public void Delete(int id)
    {
      var target = _customerContext.Customers.FirstOrDefault(x => x.Id == id);
      if (target is not null)
      {
        _customerContext.Customers.Remove(target);
        _customerContext.SaveChanges();
      }
    }

    public void Add(Customer customer)
    {
      _customerContext.Customers.Add(customer);
      _customerContext.SaveChanges();
    }
  }
}