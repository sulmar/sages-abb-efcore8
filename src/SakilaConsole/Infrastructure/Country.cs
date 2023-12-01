using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Country
{
    public short CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    public DateTime? LastUpdate { get; set; }

    public ICollection<City> Cities { get; set; } = new ObservableCollection<City>();
}
