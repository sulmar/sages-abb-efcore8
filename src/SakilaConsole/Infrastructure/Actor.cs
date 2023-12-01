     using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class Actor
{
    public int ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public ICollection<FilmActor> FilmActors { get; set; } = new ObservableCollection<FilmActor>();
}
