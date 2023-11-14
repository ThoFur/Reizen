using Model.Entities;

namespace Reizen2.Models
{
    public class BoekenKlantenViewModel
    {
        public BoekenViewModel BoekenViewModel { get; set; }
        public IEnumerable<Klant> Klanten { get; set; }
    }
}
