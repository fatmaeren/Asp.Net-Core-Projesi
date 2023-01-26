using Microsoft.AspNetCore.Http;

namespace Core_ProjeGerçek.Models
{
    public class DeneyimEkle
    {
        public int ExperienceID { get; set; }
        public string ExperienceAd { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
