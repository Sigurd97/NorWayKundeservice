using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class FaqInnDAL
    {

        public int AddFAQInn(FAQInn FAQInn)
        {
            using (var db = new NorWayContext())
            {
                try
                {
                    db.FAQInn.Add(FAQInn);
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
