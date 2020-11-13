using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorWayKundeservice.Models;

namespace NorWayKundeservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NorWayFaqController : ControllerBase
    {

        FAQDAL faqDAL = new FAQDAL();
        FaqInnDAL faqinnDAL = new FaqInnDAL();
        MainKategoriDAL MainKategorierDAL = new MainKategoriDAL();
        SubKategoriDAL SubKategorierDAL = new SubKategoriDAL();

        [HttpGet]
        public IEnumerable<SubKategori> SubKategorier(int mainKategoriId)
        {
            var subKategorier = SubKategorierDAL.GetSubKategorierFromMainKategoriId(mainKategoriId);
            return subKategorier;
        }

        [HttpGet]
        public IEnumerable<FAQ> FAQs(int subKategoriId)
        {
            var faqs = faqDAL.GetFAQsFromSubKategoriId(subKategoriId);
            return faqs;
        }

        [HttpGet]
        public IEnumerable<MainKategori> MainKategorier()
        {
            var mainKategorier = MainKategorierDAL.GetAllMainkategorier();
            return mainKategorier;
        }

        [HttpGet]
        public ActionResult MainKategori(int MainKategoriId)
        {
            var MainKategori = MainKategorierDAL.GetMainkategori(MainKategoriId);
            var converted = JsonConvert.SerializeObject(MainKategori.Navn, null, new JsonSerializerSettings());
            return Content(converted, "application/json");
        }

        [HttpGet]
        public void FAQRating(int faqId, int rating)
        {
            faqDAL.UpdateFAQRating(faqId, rating);
        }

        [HttpPost]
        public IActionResult FAQInn([FromForm]FAQInn inn)
        {
            faqinnDAL.AddFAQInn(inn);
            return Ok();
        }

    }
}