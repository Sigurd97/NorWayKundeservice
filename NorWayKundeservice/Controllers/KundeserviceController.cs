using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorWayKundeservice.Models;

namespace NorWayKundeservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KundeserviceController : ControllerBase
    {

        FAQDAL faqDAL = new FAQDAL();
        FAQInnsendtDAL faqinnsendtDAL = new FAQInnsendtDAL();
        HovedkategoriDAL hovedkategorierDAL = new HovedkategoriDAL();
        UnderkategoriDAL underkategorierDAL = new UnderkategoriDAL();

        [HttpGet]
        public IEnumerable<Underkategori> Underkategorier(int hovedkategoriId)
        {
            var underkategorier = underkategorierDAL.GetUnderkategorierFromHovedkategoriId(hovedkategoriId);
            return underkategorier;
        }

        [HttpGet]
        public IEnumerable<FAQ> FAQs(int underkategoriId)
        {
            var faqs = faqDAL.GetFAQsFromUnderkategoriId(underkategoriId);
            return faqs;
        }

        [HttpGet]
        public IEnumerable<Hovedkategori> Hovedkategorier()
        {
            var hovedkategorier = hovedkategorierDAL.GetAllHovedkategorier();
            return hovedkategorier;
        }

        [HttpGet]
        public ActionResult Hovedkategori(int hovedkategoriId)
        {
            var hovedkategori = hovedkategorierDAL.GetHovedkategori(hovedkategoriId);
            var converted = JsonConvert.SerializeObject(hovedkategori.Navn, null, new JsonSerializerSettings());
            return Content(converted, "application/json");
        }

        [HttpGet]
        public void FAQRating(int faqId, int rating)
        {
            faqDAL.UpdateFAQRating(faqId, rating);
        }

        [HttpPost]
        public IActionResult FAQInnsendt([FromForm]FAQInnsendt innsendt)
        {
            faqinnsendtDAL.AddFAQInnsendt(innsendt);
            return Ok();
        }

    }
}