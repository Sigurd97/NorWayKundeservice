using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorWayKundeservice
{
    public class MainKategori
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public List<SubKategori> SubKategorier { get; set; }
    }
}