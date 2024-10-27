using System;
using System.Collections.Generic;

namespace S00DataDll.Data;

public partial class Mercado
{
    public int Id { get; set; }

    public string? NomMercado { get; set; }

    public virtual ICollection<Grafico> Grafico { get; set; } = new List<Grafico>();
}
