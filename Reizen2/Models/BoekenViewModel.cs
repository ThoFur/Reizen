using Model.Entities;

namespace Reizen2.Models
{
    public class BoekenViewModel
    {
        public Reis? Reis { get; set; }
        public string? Bestemming { get; set; }
        public List<Klant>? Klanten { get; set; }
        
    }
}
