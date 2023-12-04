using EjercicioIFC.Domain.Entities;
using EjercicioIFC.Repository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace EjercicioIFC
{
    internal class Program
    {
        public static readonly string FECHA_PROCESO = "fecha";
        public delegate void PrintCustom(string path);

        static void Main(string[] args)
        {


            List<string> Data = File.ReadAllLines(@"C:\Users\user\Desktop\CDA Capacitación\Taller-CDA\EjercicioIFC\EjercicioIFC\Repository\data.txt").ToList();
            string stringconnection = @"Data Source=localhost;Initial Catalog=db.ventas_mensauales;Integrated Security=True;Trust Server Certificate=True";

            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(stringconnection).Options;

            var context = new DatabaseContext(options);

            string dataParametria = context.Parametria.Where(w => w.Regla == FECHA_PROCESO).First().ValorRegla;
            DateTime fechaProceso = DateTime.ParseExact(dataParametria, "yyyy-MM-dd", CultureInfo.InvariantCulture);


            foreach (string line in Data)
            {
               Rechazos rechazos = CargaRechazos(line, fechaProceso);
            }
            

            
            
            
           
        
        }

        private static Rechazos? CargaRechazos(string data, DateTime fechaProceso)
           
        {
            string[] marcaGrande = new string[] { "S", "N" };

            StringBuilder rechazos = new StringBuilder();

            string fechaProcesoLine = data.Substring(0, 8).Trim(); //recortamos la cadena de string y con .Trim se borran los espacios
            string codigoVendedorLine = data.Substring(8, 3).Trim();
            string ventaLine = data.Substring(11, 11).Trim();
            string empresaGrande = data.Substring(22, 1).Trim();

        }  
    
    
    
    
    
    }

}
