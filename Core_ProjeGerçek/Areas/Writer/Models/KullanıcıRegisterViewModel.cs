using System.ComponentModel.DataAnnotations;

namespace Core_ProjeGerçek.Areas.Writer.Models
{
    public class KullanıcıRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Ad Giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyad Giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Fotograf Giriniz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz.")]
        [Compare ("Password", ErrorMessage ="Şifreler aynı değil.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz.")]
        public string Mail { get; set; }
    }
}
