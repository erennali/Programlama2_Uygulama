using Entities.DbContextFolder;
using Programlama2_UygulamaProjesi.Abstracts;
using Programlama2_UygulamaProjesi.Concrete;
using Programlama2_UygulamaProjesi.Entities;
using System;

public class KonuService : IKonuService
{
    private OdevDbContext _context;



    public KonuService(OdevDbContext context)
    {
        _context = context;
    }

    private string GetKonuAdi(KonuClass konu)
    {
        if (konu.ParentId == null)
        {
            return konu.KonuAdi;
        }

        var parentKonu = _context.Konular.Find(konu.ParentId);
        return $"{GetKonuAdi(parentKonu)} - {konu.KonuAdi}";
    }
    int id = 0;
    public void KonuEkle(KonuEkleDto input)
    {
        var yeniKonu = new KonuClass
        {
            Id = id++,
            KonuAdi = input.KonuAdi,
            ParentId = input.ParentId
        };

        _context.Konular.Add(yeniKonu);
        _context.SaveChanges();
    }

    public void KonuGuncelle(KonuGuncelleDto input)
    {
        var konu = _context.Konular.Find(input.Id);

        if (konu == null)
        {
            throw new Exception("Güncellenecek konu bulunamadı.");
        }

        konu.KonuAdi = input.KonuAdi;
        konu.ParentId = input.ParentId;

        _context.Konular.Update(konu);
        _context.SaveChanges();
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

    public List<KonuDto> GetTumKonular()
    {

        var tumKonular = new List<KonuDto>();

        // Ana konuları al
        var anaKonular = _context.Konular.Where(k => k.ParentId == null).ToList();

        // Her ana konu için alt konuları al ve listeye ekle
        foreach (var anaKonu in anaKonular)
        {
            tumKonular.Add(new KonuDto { Id = anaKonu.Id, KonuAdi = anaKonu.KonuAdi });

            var altKonular = _context.Konular.Where(k => k.ParentId == anaKonu.Id).ToList();
            foreach (var altKonu in altKonular)
            {
                tumKonular.Add(new KonuDto { Id = altKonu.Id, KonuAdi = $"{anaKonu.KonuAdi} - {altKonu.KonuAdi}" });

                // Alt konuların altını da kontrol edersek recursive bir yapı elde edebiliriz.
            }
        }

        // Alfabetik sıralama yap
        tumKonular = tumKonular.OrderBy(k => k.KonuAdi).ToList();

        return tumKonular;

    }
}

