using Programlama2_UygulamaProjesi.Entities;
using System;
using static Programlama2_UygulamaProjesi.Entities.SoruClass;

public class SoruEkleDto
{
    public string SoruKoku { get; set; }
    public int KonuId { get; set; }
    public ZorlukDerecesi ZorlukDerecesi { get; set; }
    public List<SoruCevapDto> Cevaplar { get; set; }
}
