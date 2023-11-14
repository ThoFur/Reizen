using Model.Entities;

namespace Reizen2.Models
{
    public class BoekingViewModel
    {
        public string Bestemming { get; set; }
        public Reis Reis { get; set; }
        public Klant Klant { get; set; }
    }
}
