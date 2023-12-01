using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Category
{
    public byte CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public ICollection<FilmCategory> FilmCategories { get; set; } = new ObservableCollection<FilmCategory>();
}
