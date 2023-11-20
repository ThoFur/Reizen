using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

public partial class Boeking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Klantid { get; set; }

    public int Reisid { get; set; }

    public DateTime GeboektOp { get; set; }
    [Required(ErrorMessage ="Verplicht veld")]
    [Range(1, 100, ErrorMessage = "De minimum- en maximumwaarden zijn : {1} en {2}")]
    public int? AantalVolwassenen { get; set; }
    
    public int? AantalKinderen { get; set; }

    public bool AnnulatieVerzekering { get; set; }

    public virtual Klant Klant { get; set; } = null!;

    public virtual Reis Reis { get; set; } = null!;
}
