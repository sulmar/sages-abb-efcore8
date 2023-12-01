using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Language
{
    public byte LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public ICollection<Film> FilmLanguages { get; set; } = new ObservableCollection<Film>();

    public ICollection<Film> FilmOriginalLanguages { get; set; } = new ObservableCollection<Film>();
}
