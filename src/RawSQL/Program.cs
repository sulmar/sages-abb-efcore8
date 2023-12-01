// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using RawSQL;
using RawSQL.Model;

Console.WriteLine("Hello, World!");

var context = new SakilaContext();

//FormattableString sql = $"SELECT * FROM Customer";

//var customers = context.Customers.FromSql(sql);

//foreach (var customer in customers)
//{
//    Console.WriteLine(customer.FirstName);
//}

//var quantity = context.Database
//        .SqlQuery<int>($"SELECT COUNT(*) FROM Customer");

//// EF Core 8.0
//var customerInfos = context.Database
//        .SqlQuery<CustomerInfo>($"SELECT first_name as FirstName, last_name as LastName FROM Customer");

//foreach (var customerInfo in customerInfos)
//{
//    Console.WriteLine(customerInfo.FirstName);
//}

//var actors = context.Actors.ToList();

//foreach (var actor in actors)
//{
//    Console.WriteLine(actor);
//}

//var actorsQuery = context.Database.SqlQuery<ActorDTO>($"SELECT [first_name] AS FirstName, [last_name] AS LastName FROM [sakila].[dbo].[actor]")
//    .Where(a => a.firstname.Contains("a"))
//    .ToList();


var query = context.Database.SqlQuery<ActorDTO>($"EXEC usp_GetActors")
    .ToList();



var newActor = new Actor { FirstName = "JOHN", LastName = "SMITH" };
context.Actors.Add(newActor);

context.SaveChanges();

Console.WriteLine(newActor.ActorId);