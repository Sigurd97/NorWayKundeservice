using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class UnderkategoriDAL
    {
        VyContext db = new VyContext();

        public IEnumerable<Underkategori> GetUnderkategorierFromHovedkategoriId(int id)
        {
            try
            {
                return db.Underkategorier.Where(u => u.HovedkategoriId == id).ToList();
            }
            catch
            {
                throw;
            }
        }     
    }
}
