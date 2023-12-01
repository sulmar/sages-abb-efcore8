using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class SalesByFilmCategory
{
    public string Category { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
