using System;
using System.Collections.Generic;

namespace Model.Entities;

public partial class Werelddeel
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Land> Landen { get; set; } = new List<Land>();
}
