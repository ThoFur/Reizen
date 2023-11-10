﻿using System;
using System.Collections.Generic;

namespace Model.Entities;

public partial class Woonplaats
{
    public int Id { get; set; }

    public int Postcode { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Klant> Klanten { get; set; } = new List<Klant>();
}
