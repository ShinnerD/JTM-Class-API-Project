using API.Models;

namespace API.Database.Repository.Interfaces
{
  public interface ICustomerRepository
  {
    public Customer? GetCustomerById(int id);
    public IEnumerable<Customer> GetAllCustomers();
    void Delete(int id);

    void Add(Customer customer);
  }
}
