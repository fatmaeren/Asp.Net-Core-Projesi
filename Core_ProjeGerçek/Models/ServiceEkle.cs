using Microsoft.AspNetCore.Http;

namespace Core_ProjeGerçek.Models
{
    public class ServiceEkle
    {
        public int ServiceID { get; set; }

        public string Title { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
