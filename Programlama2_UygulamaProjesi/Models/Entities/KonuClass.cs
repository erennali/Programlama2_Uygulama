using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities;

public class KonuClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime KayitTarihi { get; set; }
    public int? ParentId { get; set; }
}
