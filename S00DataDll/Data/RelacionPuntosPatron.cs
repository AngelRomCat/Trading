using System;
using System.Collections.Generic;

namespace S00DataDll.Data;

public partial class RelacionPuntosPatron
{
    public int Id { get; set; }

    public int IdPatron { get; set; }

    public int? XAMasB { get; set; }

    public int? XA { get; set; }

    public int? PuntA { get; set; }

    public int? XB { get; set; }

    public int? PuntB { get; set; }

    public string? Relacion { get; set; }

    public int? XCMasD { get; set; }

    public int? XC { get; set; }

    public int? PuntC { get; set; }

    public int? XD { get; set; }

    public int? PuntD { get; set; }

    public virtual Patron IdPatronNavigation { get; set; } = null!;
}
