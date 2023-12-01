using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Store
{
    public int StoreId { get; set; }

    public byte ManagerStaffId { get; set; }

    public int AddressId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public ICollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    public ICollection<Inventory> Inventories { get; set; } = new ObservableCollection<Inventory>();

    public virtual Staff ManagerStaff { get; set; } = null!;

    public ICollection<Staff> Staff { get; set; } = new ObservableCollection<Staff>();
}
