using Model.Entities;

namespace Reizen2.Models
{
    public interface IWerelddelenRepository
    {
        
        IEnumerable<Werelddeel> GetAll();
        IEnumerable<Land> GetLanden(int id);
        IEnumerable<Bestemming> GetBestemmingen(int id);
        IEnumerable<Reis> GetReizen(string code);
        Reis? GetReis(int id);
        List<Klant> GetKlanten(string naam);
        Klant GetKlant(int id);
        public void  DoeBoeking(Boeking boeking);
    }
}
