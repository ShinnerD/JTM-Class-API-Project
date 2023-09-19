using API.Database.Repository.Interfaces;
using API.Models;
using API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerRepository repository;

    public CustomerController(ICustomerRepository repository)
    {
      this.repository = repository;
    }

    // GET: api/<CustomerController>
    [HttpGet]
    public IEnumerable<int> Get()
    {
      return repository.GetAllCustomers().Select(x => x.Id).ToArray();
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public ActionResult<Customer?> Get(int id)
    {
      var customer = repository.GetCustomerById(id);
      if (customer is null)
        return NotFound("No customers found with the provided Id");

      return Ok(customer);
    }

    // POST api/<CustomerController>
    [HttpPost]
    public string Post([FromBody] CustomerCreateRequest customer)
    {
      var newCustomer = new Customer()
      {
        FirstName = customer.FirstName,
        LastName = customer.LastName,
      };

      repository.Add(newCustomer);

      return "New customer added. Id: " + newCustomer.Id;
    }

    // PUT api/<CustomerController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      var target = repository.GetCustomerById(id);

      if (target is null)
        return $"No customer with id {id}";

      repository.Delete(id);
      return $"Customer with id {id} successfully deleted.";
    }
  }
}
