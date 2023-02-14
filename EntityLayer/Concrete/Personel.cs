using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Personel : BaseEntity
    {
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Telefon { get; set; }
    }
}
