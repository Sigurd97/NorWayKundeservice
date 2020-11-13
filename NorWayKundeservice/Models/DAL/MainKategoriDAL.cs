using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class MainKategoriDAL
    {
        NorWayContext db = new NorWayContext();
        public IEnumerable<MainKategori> GetAllMainkategorier()
        {
            try
            {
                return db.MainKategorier.ToList();
            }
            catch
            {
                throw;
            }
        }
   
        public MainKategori GetMainkategori(int id)
        {
            try
            {
                MainKategori mainKategori = db.MainKategorier.Include("SubKategorier").FirstOrDefault(h => h.Id == id);
                return mainKategori;
            }
            catch
            {
                throw;
            }
        }
    }
}
