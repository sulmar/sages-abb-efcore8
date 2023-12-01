using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int FilmId { get; set; }

    public int StoreId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Film Film { get; set; } = null!;

    public ICollection<Rental> Rentals { get; set; } = new ObservableCollection<Rental>();

    public virtual Store Store { get; set; } = null!;
}
