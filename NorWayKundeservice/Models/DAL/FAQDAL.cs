using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class FAQDAL
    {
        public IEnumerable<FAQ> GetFAQsFromSubKategoriId(int id)
        {
            using (var db = new NorWayContext())
            {
                try
                {
                    return db.FAQ.Where(f => f.SubKategoriId == id).OrderByDescending(r=> r.Rating).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

 
       public bool UpdateFAQRating(int faqId, int rating)
        {
            using (var db = new NorWayContext())
            {
                try
                {
                    var faq = db.FAQ.Find(faqId);
                    faq.Rating = rating;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
