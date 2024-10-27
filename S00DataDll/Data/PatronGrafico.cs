using System;
using System.Collections.Generic;

namespace S00DataDll.Data;

public partial class PatronGrafico
{
    public int Id { get; set; }

    public int IdPatron { get; set; }

    public int IdGraficPrimerRegistre { get; set; }

    public DateTime? FechaGraficPrimerRegistre { get; set; }

    public int? IdMercadoGraficPrimerRegistre { get; set; }

    public string? NomMercadoGraficPrimerRegistre { get; set; }

    public virtual Grafico IdGraficPrimerRegistreNavigation { get; set; } = null!;

    public virtual Patron IdPatronNavigation { get; set; } = null!;
}
