public class SinavSoruDto
{
    public Guid SoruId { get; set; }
    public string SoruKoku { get; set; }
    public List<SinavSoruCevapDto> Cevaplar { get; set; }
}