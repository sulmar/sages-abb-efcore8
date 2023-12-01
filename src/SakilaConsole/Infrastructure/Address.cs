using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Address
{
    public int AddressId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string District { get; set; } = null!;

    public int CityId { get; set; }

    public string? PostalCode { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public virtual City City { get; set; } = null!;

    public ICollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    public ICollection<Staff> Staff { get; set; } = new ObservableCollection<Staff>();

    public ICollection<Store> Stores { get; set; } = new ObservableCollection<Store>();
}
