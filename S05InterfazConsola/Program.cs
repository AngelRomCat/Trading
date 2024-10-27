using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using S00DataDll.Data;
using S05InterfazConsola.Services.A0Service;
using S05InterfazConsola.Services.DataBaseService;
//Crea una nueva C:\Fci\06C#Mvc\SolucionRepasoDdbb, con un proyecto principal de consola S05InterfazConsola
//En este proyecto, crea una clase Class1 con una interfaz IClass1
//En la que habrá un constructor y un método llamado MetodoPrincipal, que no recibe parámetros pero devuelve un string
//A continuación, crea una clase Class2 con una interfaz IClass2 
//En la que habrá un constructor y un método llamado MetodoSecundario, que no recibe parámetros pero devuelve un string, con el valor: “Estamos en la clase Class2, MetodoSecundario”
//El MetodoPrincipal de la clase Class1, utilizará un objeto de la clase Class2 para poder acceder al método MetodoSecundario el cual le pasará un string que el MetodoPrincipal devolverá a Program, el cual lo mostrará por pantalla…

//IClass1 class1 = new Class1();
//string miString = class1.MetodoPrincipal();
//Console.WriteLine(miString);

//Todo ello debe funcionar con Inyección de dependencias y asincronismo.

//Lo primero que hace program es llamar al inyector
//Crea un objeto de la clase inyector, (Microsoft.Extensions.Hosting.HostApplicationBuilder)
//Y lo inicializa
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//ES un proyecto conectado a una DDBB
//Por tanto, le indicamos al inyector donde se encuetra el archivo DdBbDbContext
var connectionString = builder.Configuration.GetConnectionString("DdBbDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DdBbDbContextConnection' not found.");
builder.Services.AddDbContext<DdBbDbContext>(options => options.UseSqlServer(connectionString));

//Voy a decirle al objeto inyector que cree un objeto de la ClasePrincipal
//builder.Services.AddSingleton<ClasePrincipal>();
////Si tiene interfaz:
//builder.Services.AddTransient<IClass1, Class1>();
//builder.Services.AddTransient<IClass2, Class2>();
//builder.Services.AddTransient<IClasePrincipal, ClasePrincipal>();
builder.Services.AddTransient<IA0Service, A0Service>();
builder.Services.AddTransient<IDataBaseService, DataBaseService>();

//Cuando he acabado de crear todos los objetos de todas las Clases que necesitaré
//Ejecuto el inyector
//El resultado se lo paso al objeto llamado app
var app = builder.Build();

//Utiliza el método MetodoPrincipal de la clase A0Service
//Mediante la interfaz IA0Service
//Si el método es asíncrono, deberemos llamarlo asíncronamente desde Program
bool miBool = await app.Services.GetRequiredService<IA0Service>().MetodoPrincipal();

Console.WriteLine(miBool);

Console.ReadLine();