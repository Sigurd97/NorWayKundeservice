using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class FAQInnsendt
    {
        [Key]
        public int Id { get; set; }
        public int HovedkategoriId { get; set; }
        public int UnderkategoriId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Epost { get; set; }
        public string Spørsmål { get; set; }
    }
}
