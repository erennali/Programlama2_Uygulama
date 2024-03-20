using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities;

public class SoruClass
{
    public Guid Id { get; set; }
    public string SoruKoku { get; set; }
    public int KonuId { get; set; }
    public enum ZorlukDerecesi
    {
        Kolay=1,
        Orta=2,
        Zor=3
    }
}
