using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class FAQDAL
    {
        public IEnumerable<FAQ> GetFAQsFromUnderkategoriId(int id)
        {
            using (var db = new VyContext())
            {
                try
                {
                    return db.FAQ.Where(f => f.UnderkategoriId == id).OrderByDescending(r=> r.Rating).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

 
       public bool UpdateFAQRating(int faqId, int rating)
        {
            using (var db = new VyContext())
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
