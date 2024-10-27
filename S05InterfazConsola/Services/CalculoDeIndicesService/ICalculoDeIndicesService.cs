
namespace S05InterfazConsola.Services.CalculoDeIndicesService
{
    internal interface ICalculoDeIndicesService
    {
        public Task<bool> MetodoPrincipal();

        public Task<bool> IndiceDeMomentumRsi();
    }
}
