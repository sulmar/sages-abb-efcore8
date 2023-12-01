// See https://aka.ms/new-console-template for more information
using TrackingChanges.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


var context = new SakilaContext();

// var customer = context.Customers.Include(p=>p.Rentals).First();

var customer = new Customer() {  CustomerId = 2  };

context.Attach(customer);

Console.WriteLine(context.Entry(customer).State);


customer.FirstName = "JOHN";

context.Entry(customer).Property(p => p.FirstName).IsModified = true;


Console.WriteLine(context.Entry(customer).State);
Console.WriteLine(context.Entry(customer).Property(p => p.FirstName).OriginalValue);
Console.WriteLine(context.Entry(customer).Property(p => p.FirstName).CurrentValue);

Console.WriteLine(context.Entry(customer).Property(p => p.FirstName).IsModified);

customer.LastName = "SPIDER";
Console.WriteLine(context.Entry(customer).State);

// context.Entry(customer).State = EntityState.Deleted;

context.Customers.Remove(customer);

Console.WriteLine(context.Entry(customer).State);
context.SaveChanges();

Console.WriteLine(context.Entry(customer).State);
