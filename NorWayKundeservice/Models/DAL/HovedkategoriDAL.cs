using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class HovedkategoriDAL
    {
        VyContext db = new VyContext();
        public IEnumerable<Hovedkategori> GetAllHovedkategorier()
        {
            try
            {
                return db.Hovedkategorier.ToList();
            }
            catch
            {
                throw;
            }
        }
   
        public Hovedkategori GetHovedkategori(int id)
        {
            try
            {
                Hovedkategori hovedkategori = db.Hovedkategorier.Include("Underkategorier").FirstOrDefault(h => h.Id == id);
                return hovedkategori;
            }
            catch
            {
                throw;
            }
        }
    }
}
