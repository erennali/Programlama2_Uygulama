using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programlama2_UygulamaProjesi.Entities;

public class KonuClass
{
    public int Id { get; set; }
    public string KonuAdi { get; set; }
    public DateTime KayitTarihi { get; set; }
    public int? ParentId { get; set; }
}
