// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Sages.ABB.Test;
using SakilaConsole.Infrastructure;

Console.WriteLine("Hello, World!");

string[] names = ["a", "b"];

SakilaContext context = new();

context.Database.EnsureCreated();


var query10 = context.Customers
            .Where(customer => customer.Email.StartsWith("M"))
            .OrderByDescending(payment => payment.FirstName)
            .Take(5)
            .ToList()
            .Where(payment => payment.FirstName[0] == 'M')
          ;

bool filterByEmail = true;

var query11 = context.Customers
            .Where(customer => customer.Email.StartsWith("M"))
            .OrderByDescending(payment => payment.FirstName)
            .Take(5)
            .ToList();

var queryM = context.Customers.AsQueryable();

if (filterByEmail)
{
    queryM = queryM.Where(customer => customer.Email.StartsWith("M"));

}

var sortedPaymentsQuery = queryM
            .OrderByDescending(payment => payment.FirstName)
            .Take(5);

var query12 = queryM.Where(c => c.LastUpdate > DateTime.Today.AddDays(-1));

foreach (var customer in query10.ToList())
{
    Console.WriteLine(customer.FirstName);
}


// Jawne ładowanie (Explicit Loading)

var customer2 = await context.Customers.FirstAsync();


var customers6 = context.Customers.AsNoTracking().ToList();

foreach (var c in customers6)
{
    await context.Entry(c).Reference(p => p.Address).LoadAsync();

    await context.Entry(c).Collection(p => p.Rentals).LoadAsync();

}





// Zachłanne ładowanie (Eadger Loading)
var customers = context.Customers
        .Include(p => p.Address.City)
        .Include(p => p.Payments)
            .ThenInclude(p => p.Rental)
                .ThenInclude(p => p.Inventory)
    .ToList();

// Filtrowanie przy pobieraniu zachlannym
var lastPayments = context.Customers
    .Include(customer => customer.Payments
            .Where(payment => payment.Amount > 1)
            .OrderByDescending(payment => payment.PaymentDate)
            .Take(5))
    .ToList();

// Split queries
var customers2 = context.Customers
        .Include(p => p.Address.City)
        .Include(p => p.Payments)
            .ThenInclude(p => p.Rental)
                .ThenInclude(p => p.Inventory)
        .AsSplitQuery()
    .ToList();

// Global Split queries
// dodajemy do konfiguracji

// Single Query
var customers4 = context.Customers
        .Include(p => p.Address.City)
        .Include(p => p.Payments)
            .ThenInclude(p => p.Rental)
                .ThenInclude(p => p.Inventory)
                .AsSingleQuery()
    .ToList();


// AutoInclude
var customers3 = context.Customers.ToList();


// IgnoreAutoIncludes
var customers7 = context.Customers
    .IgnoreAutoIncludes()
    .ToList();





foreach (var customer in customers3)
{
    Console.WriteLine($"{customer.FirstName} {customer.Address.Address1}");
}