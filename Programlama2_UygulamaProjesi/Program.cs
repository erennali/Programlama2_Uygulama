
using Entities.DbContextFolder;
using Microsoft.EntityFrameworkCore;
using Programlama2_UygulamaProjesi.Abstracts;
using Programlama2_UygulamaProjesi.Concrete.Konu;
using Programlama2_UygulamaProjesi.Concrete.SoruConcrete;

namespace denemee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

           



            var _context = new OdevDbContext();

            app.MapGet("/konu", () =>
            {
                IKonuService konuService = new KonuService(_context);
                return konuService.GetTumKonular();

            });


            app.MapPost("/konu", (KonuEkleDto input) =>
            {
                IKonuService konuService = new KonuService(_context);
                konuService.KonuEkle(input);

            });


            app.MapPut("/konu", (KonuGuncelleDto input) =>
            {
                IKonuService konuService = new KonuService(_context);
                konuService.KonuGuncelle(input);

            });


            app.MapDelete("/konu", (int Id) =>
            {
                IKonuService konuService = new KonuService(_context);
                konuService.KonuSil(Id);

            });


            app.MapPost("/soru", (SoruEkleDto input) =>
            {
                ISoruService soruService = new SoruService(_context);
                soruService.SoruEkle(input);

            });


            app.MapPost("/soruGuncel", (SoruGuncelleDto input) =>
            {
                ISoruService soruService = new SoruService(_context);
                soruService.SoruGuncelle(input);

            });


            app.MapPost("/deneme", (DenemeSinaviOlusturInput input) =>
            {
                ISoruService soruService = new SoruService(_context);
                soruService.DenemeSinaviOlustur(input);

            });



            app.MapPost("/sonuc", (SinavSonucunuHesaplaInput input) =>
            {
                ISoruService soruService = new SoruService(_context);
                soruService.SinavSonucunuHesapla(input);

            });







            app.Run();

        }








    }


}
