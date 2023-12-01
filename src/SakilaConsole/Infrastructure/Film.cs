using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Film
{
    public int FilmId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ReleaseYear { get; set; }

    public byte LanguageId { get; set; }

    public byte? OriginalLanguageId { get; set; }

    public byte RentalDuration { get; set; }

    public decimal RentalRate { get; set; }

    public short? Length { get; set; }

    public decimal ReplacementCost { get; set; }

    public string? Rating { get; set; }

    public string? SpecialFeatures { get; set; }

    public DateTime LastUpdate { get; set; }

    public ICollection<FilmActor> FilmActors { get; set; } = new ObservableCollection<FilmActor>();

    public ICollection<FilmCategory> FilmCategories { get; set; } = new ObservableCollection<FilmCategory>();

    public ICollection<Inventory> Inventories { get; set; } = new ObservableCollection<Inventory>();

    public virtual Language Language { get; set; } = null!;

    public virtual Language? OriginalLanguage { get; set; }
}
