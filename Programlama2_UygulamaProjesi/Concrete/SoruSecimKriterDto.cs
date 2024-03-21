using Programlama2_UygulamaProjesi.Entities;
using static Programlama2_UygulamaProjesi.Entities.SoruClass;

public class SoruSecimKriterDto
{
    public int KonuId { get; set; } // Seçilen konunun Id'si
    public ZorlukDerecesi ZorlukDerecesi { get; set; } // Sorunun zorluk derecesi
    public int SoruSayisi { get; set; } // Seçilen konudan alınacak soru sayısı
}
