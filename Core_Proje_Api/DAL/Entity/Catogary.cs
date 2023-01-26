using System.ComponentModel.DataAnnotations;

namespace Core_Proje_Api.DAL.Entity
{
    public class Catogary
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriName { get; set; }
    }
}
