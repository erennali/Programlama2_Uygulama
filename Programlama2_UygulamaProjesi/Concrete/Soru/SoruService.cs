using Entities.DbContextFolder;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Programlama2_UygulamaProjesi.Abstracts;
using Programlama2_UygulamaProjesi.Entities;
using static Programlama2_UygulamaProjesi.Entities.SoruClass;


namespace Programlama2_UygulamaProjesi.Concrete.SoruConcrete
{
    public class SoruService : ISoruService
    {
        private OdevDbContext _context;

        public SoruService(OdevDbContext context)
        {
            _context = context;
        }

        public List<SinavSoruDto> DenemeSinaviOlustur(DenemeSinaviOlusturInput input)
        {
            var sorular = new List<SinavSoruDto>();

            foreach (var kriter in input.SoruSecimKriterleri)
            {
                var konuSorulari = _context.Sorular
                    .Where(s => s.KonuId == kriter.KonuId && s.ZorlukDerecesi == kriter.ZorlukDerecesi)
                    .OrderBy(r => Guid.NewGuid())
                    .Take(kriter.SoruSayisi)
                    .ToList();

                foreach (var soru in konuSorulari)
                {
                    var cevaplar = _context.SoruAndCevap.Where(c => c.SoruId == soru.Id).ToList();
                    var secilenCevaplar = cevaplar.OrderBy(c => Guid.NewGuid()).ToList();

                    var sinavSoru = new SinavSoruDto
                    {
                        SoruId = soru.Id,
                        SoruKoku = soru.SoruKoku,
                        Cevaplar = secilenCevaplar.Select(c => new SinavSoruCevapDto
                        {
                            CevapId = c.Id,
                            Cevap = c.Cevap
                        }).ToList()
                    };

                    sorular.Add(sinavSoru);
                }
            }

            return sorular.OrderBy(r => Guid.NewGuid()).ToList();
        }

        public SinavSonucDto SinavSonucunuHesapla(SinavSonucunuHesaplaInput input)
        {
            int dogruCevapSayisi = 0;
            int yanlisCevapSayisi = 0;
            int bosCevapSayisi = 0;

            foreach (var cevap in input.Cevaplar)
            {
                var soru = _context.Sorular.Find(cevap.SoruId);
                if (soru == null)
                {
                    continue;
                }

                if (cevap.CevapId == Guid.Empty)
                {
                    bosCevapSayisi++;
                }
                else
                {
                    var dogruCevap = _context.SoruAndCevap.FirstOrDefault(c => c.SoruId == soru.Id && c.Sira == 0);
                    if (dogruCevap != null && dogruCevap.Id == cevap.CevapId)
                    {
                        dogruCevapSayisi++;
                    }
                    else
                    {
                        yanlisCevapSayisi++;
                    }
                }
            }

            return new SinavSonucDto
            {
                DogruCevapSayisi = dogruCevapSayisi,
                YanlisCevapSayisi = yanlisCevapSayisi,
                BosCevapSayisi = bosCevapSayisi
            };
        }

        public void SoruEkle(SoruEkleDto input)
        {

            var soru = new SoruClass
            {
                Id = Guid.NewGuid(),
                SoruKoku = input.SoruKoku,
                KonuId = input.KonuId,
                ZorlukDerecesi = input.ZorlukDerecesi
            };


            _context.Sorular.Add(soru);


            _context.SaveChanges();
        }

        public void SoruGuncelle(SoruGuncelleDto input)
        {
            var soru = _context.Sorular.Find(input.SoruId);

            if (soru == null)
            {
                throw new Exception("Soru bulunamadı");
            }


            soru.SoruKoku = input.SoruKoku;
            soru.KonuId = input.KonuId;
            soru.ZorlukDerecesi = input.ZorlukDerecesi;

            _context.Sorular.Update(soru);
            _context.SaveChanges();
        }


    }
}

