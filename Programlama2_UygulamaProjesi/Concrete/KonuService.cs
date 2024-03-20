using Entities.DbContextFolder;
using Programlama2_UygulamaProjesi.Abstracts;
using Programlama2_UygulamaProjesi.Concrete;
using System;

public class KonuService : IKonuService
{
    private readonly OdevDbContext _context;

    public KonuService(OdevDbContext context)
    {
        _context = context;
    }


    public List<KonuDto> GetTumKonular()
    {
        throw new NotImplementedException();
    }
    public void KonuEkle(KonuEkleDto input)
    {
        throw new NotImplementedException();
    }

    public void KonuGuncelle(KonuGuncelleDto input)
    {
        throw new NotImplementedException();
    }
    public void KonuSil(int id)
    {
        var konu = _context.Konular.FirstOrDefault(k => k.Id == id);
        if (konu != null)
        {
            // Alt konuların ParentId'sini güncelle
            var altKonular = _context.Konular.Where(k => k.ParentId == konu.Id).ToList();
            foreach (var altKonu in altKonular)
            {
                altKonu.ParentId = konu.ParentId;
            }

            _context.Konular.Remove(konu);
            _context.SaveChanges();
        }
    }

    List<KonuDto> IKonuService.GetTumKonular()
    {
        throw new NotImplementedException();
    }
}