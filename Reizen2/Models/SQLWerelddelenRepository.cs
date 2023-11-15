using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Repositories;

namespace Reizen2.Models
{
    public class SQLWerelddelenRepository : IWerelddelenRepository
    {
        private readonly ReizenContext context;
        public SQLWerelddelenRepository(ReizenContext context)
        {
            this.context = context;
        }

        public IEnumerable<Werelddeel> GetAll()
        {
            return context.Werelddelen.AsNoTracking();
        }

        public IEnumerable<Land> GetLanden(int id)
        {
            return context.Landen.Where(w => w.Werelddeelid == id);
             
        }

        public IEnumerable<Bestemming> GetBestemmingen(int id)
        {
            return context.Bestemmingen.Where(b => b.Landid == id);
        }

        public IEnumerable<Reis> GetReizen(string code)
        {
            return context.Reizen.Where(b => b.Bestemmingscode == code).ToList();
        }

        public Reis? GetReis(int id)
        { 
            return context.Reizen.Find(id);
        }
        public List<Klant> GetKlanten(string naam)
        {

            return context.Klanten.Include(w => w.Woonplaats).Where(k => k.Familienaam.Contains(naam)).ToList();
            
        }
        public Klant GetKlant(int id)
        {
            return context.Klanten.Include(W => W.Woonplaats).Where(k => k.Id == id).FirstOrDefault();
        }

       

        void IWerelddelenRepository.DoeBoeking(Boeking boeking)
        {
            context.Boekingen.Add(boeking);
            context.SaveChanges();
            
        }
    }
}
