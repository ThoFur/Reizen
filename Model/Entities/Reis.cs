﻿using System;
using System.Collections.Generic;

namespace Model.Entities;

public partial class Reis
{
    public int Id { get; set; }

    public string Bestemmingscode { get; set; } = null!;

    public DateTime Vertrek { get; set; }

    public int AantalDagen { get; set; }

    public decimal PrijsPerPersoon { get; set; }

    public int AantalVolwassenen { get; set; }

    public int AantalKinderen { get; set; }

    public virtual Bestemming BestemmingscodeNavigation { get; set; } = null!;

    public virtual ICollection<Boeking> Boekingen { get; set; } = new List<Boeking>();
}
