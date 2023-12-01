using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Rental
{
    public int RentalId { get; set; }

    public DateTime RentalDate { get; set; }

    public int InventoryId { get; set; }

    public int CustomerId { get; set; }

    public DateTime? ReturnDate { get; set; }

    public byte StaffId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new ObservableCollection<Payment>();

    public virtual Staff Staff { get; set; } = null!;
}
