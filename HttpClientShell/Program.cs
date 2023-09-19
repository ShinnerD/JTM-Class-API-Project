using System.Net.Http.Json;
using API.Models;
using API.Models.Requests;

namespace ConsoleApp59WebClient
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var menuChoice = "";

      while (menuChoice != "5")
      {
        Console.WriteLine("HTTP Customer Client Shell Options:");
        Console.WriteLine("1. List Customer Indexes");
        Console.WriteLine("2. Access Customer");
        Console.WriteLine("3. Create New Customer");
        Console.WriteLine("4. Delete Customer");
        Console.WriteLine("5. Exit");
        Console.WriteLine("");

        menuChoice = Console.ReadLine();

        switch (menuChoice)
        {
          case "1":
            await ListCustomerIndexes();
            break;
          case "2":
            await AccessCustomerInfo();
            break;
          case "3":
            await PostNewCustomer();
            break;
          case "4":
            await DeleteCustomer();
            break;
        }
      }

      Environment.Exit(0);
    }

    private static async Task DeleteCustomer()
    {
      Console.WriteLine("Delete a customer.. ");

      var tryParse = false;
      int customerNumber = 0;

      while (!tryParse)
      {
        Console.WriteLine("Please enter customer Id: ");
        tryParse = int.TryParse(Console.ReadLine(), out customerNumber);
      }

      var url = "https://localhost:32768/api/Customer/" + customerNumber;

      using (HttpClient client = new HttpClient())
      {
        client.Timeout = TimeSpan.FromSeconds(30);

        HttpResponseMessage response = await client.DeleteAsync(url);


        if (response.IsSuccessStatusCode)
        {
          Console.WriteLine(" ");
          string responseBody = await response.Content.ReadAsStringAsync();
          Console.WriteLine(" ");
          Console.WriteLine(responseBody);
        }
        else
        {
          Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
      }
    }

    private static async Task PostNewCustomer()
    {
      Console.WriteLine("Create New Customer: ");
      Console.WriteLine("Please enter new customer first name: ");

      var newFirstName = Console.ReadLine();

      Console.WriteLine("Please enter new customer last name: ");
      var newLastName = Console.ReadLine();

      var url = "https://localhost:32768/api/Customer";

      var newCustomer = new CustomerCreateRequest()
      {
        FirstName = newFirstName,
        LastName = newLastName
      };

      using (HttpClient client = new HttpClient())
      {
        client.Timeout = TimeSpan.FromSeconds(30);

        HttpResponseMessage response = await client.PostAsJsonAsync(url, newCustomer);

        if (response.IsSuccessStatusCode)
        {
          string responseBody = await response.Content.ReadAsStringAsync();
          Console.WriteLine(" ");
          Console.WriteLine(responseBody);
          Console.WriteLine(" ");
        }
        else
        {
          Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
      }
    }

    private static async Task AccessCustomerInfo()
    {
      try
      {
        Console.WriteLine("Please enter customer Id: ");
        var requestedId = Console.ReadLine();

        var url = "https://localhost:32768/api/Customer/" + requestedId;

        using (HttpClient client = new HttpClient())
        {
          client.Timeout = TimeSpan.FromSeconds(30);

          HttpResponseMessage response = await client.GetAsync(url);

          if (response.IsSuccessStatusCode)
          {
            var retrievedCustomer = await response.Content.ReadFromJsonAsync<Customer?>();
            Console.WriteLine(" ");
            Console.WriteLine("Customer Id: " + retrievedCustomer?.Id);
            Console.WriteLine("Customer Name: " + retrievedCustomer?.FirstName + " " + retrievedCustomer?.LastName);
            Console.WriteLine(" ");
          }
          else
          {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
          }
        }
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine($"HTTP request error: {e.Message}");
      }
      catch (TaskCanceledException e)
      {
        Console.WriteLine($"Request timed out: {e.Message}");
      }
    }

    private static async Task ListCustomerIndexes()
    {
      using (HttpClient client = new HttpClient())
      {
        try
        {
          var url = "https://localhost:32768/api/Customer";
          // Set a timeout for the HTTP request
          client.Timeout = TimeSpan.FromSeconds(30);

          HttpResponseMessage response = await client.GetAsync(url);

          if (response.IsSuccessStatusCode)
          {
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            Console.WriteLine(" ");
          }
          else
          {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            Console.WriteLine(" "); 
          }
        }
        catch (HttpRequestException e)
        {
          Console.WriteLine($"HTTP request error: {e.Message}");
        }
        catch (TaskCanceledException e)
        {
          Console.WriteLine($"Request timed out: {e.Message}");
        }
      }
    }
  }
}