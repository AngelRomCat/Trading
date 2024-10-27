using System;
using System.Collections.Generic;

namespace S00DataDll.Data;

public partial class Grafico
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Apertura { get; set; }

    public decimal? AperturaPorCierreDeAyer { get; set; }

    public decimal? Max { get; set; }

    public decimal? Min { get; set; }

    public decimal? Cierre { get; set; }

    public decimal? AjusteCierre { get; set; }

    public int? Volumen { get; set; }

    public int IdMercado { get; set; }

    public decimal? TendenciaAlza40 { get; set; }

    public decimal? TendenciaBaja40 { get; set; }

    public decimal? Resistencia40 { get; set; }

    public decimal? Soporte40 { get; set; }

    public decimal? TendenciaAlza200 { get; set; }

    public decimal? TendenciaBaja200 { get; set; }

    public decimal? Resistencia200 { get; set; }

    public decimal? Soporte200 { get; set; }

    public decimal? Rsi09 { get; set; }

    public decimal? Rsi14 { get; set; }

    public decimal? Rsi25 { get; set; }

    public decimal? Sma40 { get; set; }

    public decimal? Sma200 { get; set; }

    public decimal? Ema12 { get; set; }

    public decimal? Ema26 { get; set; }

    public decimal? Fibonacci2340 { get; set; }

    public decimal? Fibonacci3840 { get; set; }

    public decimal? Fibonacci5040 { get; set; }

    public decimal? Fibonacci6140 { get; set; }

    public decimal? Fibonacci23200 { get; set; }

    public decimal? Fibonacci38200 { get; set; }

    public decimal? Fibonacci50200 { get; set; }

    public decimal? Fibonacci61200 { get; set; }

    public int? Iegx { get; set; }

    public decimal? Iegy { get; set; }

    public int? IegxP { get; set; }

    public decimal? IegyP { get; set; }

    public decimal? IegyS { get; set; }

    public decimal? IegySp { get; set; }

    public virtual Mercado IdMercadoNavigation { get; set; } = null!;

    public virtual ICollection<PatronGrafico> PatronGrafico { get; set; } = new List<PatronGrafico>();
}
