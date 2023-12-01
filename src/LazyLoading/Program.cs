// See https://aka.ms/new-console-template for more information
using LazyLoading.Infrastructure;

Console.WriteLine("Hello, World!");


// Lazy Loading (opoznione ladowanie) z Proxy

// dotnet add package Microsoft.EntityFrameworkCore.Proxies

var context = new SakilaContext();

var customers = context.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.Address.City.City1}");
}

// Lazy Loading (opoznione ladowanie) bez Proxy

// dotnet add package Microsoft.EntityFrameworkCore.Abstraction

// ILazyLoader




