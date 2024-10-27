
using Microsoft.EntityFrameworkCore;
using S00DataDll.Data;

namespace S05InterfazConsola.Services.DataBaseService
{
    internal class DataBaseService: IDataBaseService
    {
        DdBbDbContext _context;
        public DataBaseService(DdBbDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Grafico>> MetodoPrueba()
        {
            //A continuación, vamos a llenar el IList<Grafico> graficos de esta nueva forma:
            //IList<Grafico> graficos = new List<Grafico>();
            //No hace falta que inicialicemos el IList<TablaMadre>
            //Ya que recibirá los valores de la Tabla de la DDBB
            //Le indicamos que nos pase:
            //TODOS los registros de la TablaMadre
            IList<Grafico> graficos = await _context.Grafico
                ////y TODOS los registros de la TablaHija
                //.Include(x => x.Pedido)
                //En forma de IList<TablaMadre>
                //De manera Asíncrona
                .ToListAsync();

            return graficos;
        }
    }
}
