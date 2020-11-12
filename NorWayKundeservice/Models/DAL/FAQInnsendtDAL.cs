using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class FAQInnsendtDAL
    {

        public int AddFAQInnsendt(FAQInnsendt FAQInnsendt)
        {
            using (var db = new VyContext())
            {
                try
                {
                    db.FAQInnsendte.Add(FAQInnsendt);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    throw;
                }
            }
        }
         
    }
}
