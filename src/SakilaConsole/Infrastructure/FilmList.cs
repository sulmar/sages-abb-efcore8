﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SakilaConsole.Infrastructure;

public partial class FilmList
{
    public int? Fid { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public decimal? Price { get; set; }

    public short? Length { get; set; }

    public string? Rating { get; set; }

    public string Actors { get; set; } = null!;
}
