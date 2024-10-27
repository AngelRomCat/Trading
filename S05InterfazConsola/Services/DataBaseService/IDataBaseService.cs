using S00DataDll.Data;

namespace S05InterfazConsola.Services.DataBaseService
{
    internal interface IDataBaseService
    {
        public Task<IList<Grafico>> MetodoPrueba();
    }
}
