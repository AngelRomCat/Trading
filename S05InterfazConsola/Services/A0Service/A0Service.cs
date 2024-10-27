using Microsoft.EntityFrameworkCore;
using S00DataDll.Data;
using S05InterfazConsola.Services.DataBaseService;

namespace S05InterfazConsola.Services.A0Service
{
    internal class A0Service: IA0Service
    {
        IDataBaseService _dataBaseService;
        public A0Service(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> MetodoPrincipal()
        {
            //A continuación, vamos a llenar el IList<Grafico> graficos de esta nueva forma:
            //IList<Grafico> graficos = new List<Grafico>();
            //No hace falta que inicialicemos el IList<TablaMadre>
            //Ya que recibirá los valores de la Tabla de la DDBB
            //Le indicamos que nos pase:
            //TODOS los registros de la TablaMadre
            IList<Grafico> graficos = await _dataBaseService.MetodoPrueba();

            //AHORA muestra esta frase por pantalla POR CADA UNO DE LOS PRODUCTOS
            string miString = "El Grafico Mara Florencia ha tramitado el pedido con fecha 2024-05-03";

            int idGrafico = 0;
            string nomGrafico = "";
            int idPedido = 0;
            DateTime fechaPedido = DateTime.MinValue;

            foreach (var miGrafico in graficos)
            {
                idGrafico = miGrafico.Id;
                fechaPedido = miGrafico.Fecha.Value;
                //if (miGrafico.Pedido != null)
                //{
                //    foreach (var pedidoDelGrafico in miGrafico.Pedido)
                //    {
                //        idPedido = pedidoDelGrafico.Id;
                //        fechaPedido = pedidoDelGrafico.FechaHora;

                miString = "El Grafico " + idGrafico + " ha tramitado el pedido con fecha " + fechaPedido;
                Console.WriteLine(miString);
                //    }
                //}
            }


            bool miBool = true;

            return miBool;
        }
    }
}
