using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorWayKundeservice
{
    public class Underkategori
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        [ForeignKey("Hovedkategori")]
        public int HovedkategoriId { get; set; }
        public Hovedkategori Hovedkategori { get; set; }
        public List<FAQ> FAQ { get; set; }
    }
}