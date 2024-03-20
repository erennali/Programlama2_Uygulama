using Programlama2_UygulamaProjesi.Concrete;

namespace Programlama2_UygulamaProjesi.Abstracts
{
    public interface IKonuService
    {
        List<KonuDto> GetTumKonular(); 
        
        void KonuEkle(KonuEkleDto input); 
        void KonuGuncelle(KonuGuncelleDto input); 
        void KonuSil(int id);
    }
}
