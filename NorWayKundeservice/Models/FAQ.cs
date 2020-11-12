using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorWayKundeservice
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Underkategori")]
        public int UnderkategoriId { get; set; }
        public string Spørsmål { get; set; }
        public string Svar { get; set; }
        public int Rating { get; set; }
    }
}