using System;
using System.Collections.Generic;

namespace S00DataDll.Data;

public partial class Patron
{
    public int Id { get; set; }

    public string? NomPatron { get; set; }

    public int? NumRegistrosNecesarios { get; set; }

    public int? NumDelRegistroDelCambio { get; set; }

    public decimal? Fiabilidad { get; set; }

    public string? UrlImagen { get; set; }

    public string? Calculo { get; set; }

    public virtual ICollection<PatronGrafico> PatronGrafico { get; set; } = new List<PatronGrafico>();

    public virtual ICollection<RelacionPuntosPatron> RelacionPuntosPatron { get; set; } = new List<RelacionPuntosPatron>();
}
