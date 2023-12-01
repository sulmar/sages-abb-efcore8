using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int StoreId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int AddressId { get; set; }

    public string Active { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new ObservableCollection<Payment>();

    public ICollection<Rental> Rentals { get; set; } = new ObservableCollection<Rental>();

    public virtual Store Store { get; set; } = null!;
}
