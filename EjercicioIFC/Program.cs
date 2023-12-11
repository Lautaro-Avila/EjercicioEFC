using EjercicioIFC.Repository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace EjercicioIFC.Domain.Entities;

internal class Program
{
    public static readonly string FECHA_PROCESO = "fecha";
    public delegate void PrintCustom(string path);

    static void Main(string[] args)
    {

        List<string> data = File.ReadAllLines(@"C:\Users\user\Desktop\CDA Capacitación\Taller-CDA\EjercicioIFC\EjercicioIFC\Repository\data.txt").ToList(); //Creamos una lista de sring, y leemos en la variabe el archivo de texto, y ylo pasamos a lista para que pueda ser leido 
        string stringconnection = @"Data Source=localhost;Initial Catalog=db.ventas_mensauales;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"; //se guarda en la variable el string de conexion 

        var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(stringconnection).Options;

        var context = new DatabaseContext(options);

        string dataParametria = context.Parametria
            .Where(w => w.Regla == FECHA_PROCESO)
            .First()
            .ValorRegla;

        DateTime fechaProceso = DateTime.ParseExact(dataParametria, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        Funciones.cargarVentas(context,data, fechaProceso);



        ConsultasBD.realizarConsultasBD(context);
    }

}
