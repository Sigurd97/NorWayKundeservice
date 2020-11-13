using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class SubKategoriDAL
    {
        NorWayContext db = new NorWayContext();

        public IEnumerable<SubKategori> GetSubKategorierFromMainKategoriId(int id)
        {
            try
            {
                return db.SubKategorier.Where(u => u.MainKategoriId == id).ToList();
            }
            catch
            {
                throw;
            }
        }     
    }
}
