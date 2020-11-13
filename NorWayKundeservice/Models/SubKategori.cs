using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorWayKundeservice
{
    public class SubKategori
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        [ForeignKey("MainKategori")]
        public int MainKategoriId { get; set; }
        public MainKategori MainKategori { get; set; }
        public List<FAQ> FAQ { get; set; }
    }
}