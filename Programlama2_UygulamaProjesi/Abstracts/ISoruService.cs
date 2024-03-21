using Programlama2_UygulamaProjesi.Abstracts;
using System;

namespace Programlama2_UygulamaProjesi.Abstracts
{
    public interface ISoruService
    {
        void SoruEkle(SoruEkleDto input); 
        void SoruGuncelle(SoruGuncelleDto input); 
        List<SinavSoruDto> DenemeSinaviOlustur(DenemeSinaviOlusturInput input); 
        SinavSonucDto SinavSonucunuHesapla(SinavSonucunuHesaplaInput input);
    }
}

