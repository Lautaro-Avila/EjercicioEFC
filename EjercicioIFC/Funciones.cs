using EjercicioIFC.Domain.Entities;
using EjercicioIFC.Repository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace EjercicioIFC
{
    public class Funciones
    {

        public static void cargarVentas(DatabaseContext context, List<string> data, DateTime fechaProceso)
        {
            foreach (string line in data)
            {
                Rechazos? rechazos = CargaRechazos(line, fechaProceso);

                if (rechazos != null)
                {
                    context.Rechazos.Add(rechazos);
                }
                else
                {
                    VentasMensuales ventasMensuales = CargaVentasMensuales(line);
                    context.VentasMensuales.Add(ventasMensuales);
                }
            }
            //context.SaveChanges();
        }


        private static Rechazos? CargaRechazos(string data, DateTime fechaProceso)

        {
            string[] marcaGrande = new string[] { "S", "N" }; // array con las marcas permitidas 

            StringBuilder rechazos = new StringBuilder();

            string fechaProcesoLine = data.Substring(0, 8).Trim(); //recortamos la cadena de string con ".Substring" y con .Trim se borran los espacios
            string codigoVendedorLine = data.Substring(8, 3).Trim();
            string ventaLine = data.Substring(11, 11).Trim();
            string empresaGrande = data.Substring(22, 1).Trim();

            bool BandConverFechaProceso = DateTime.TryParseExact(fechaProcesoLine, "yyyyMMdd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime fechaArchivo); // busque info del metodo datetime.tryparseexact, pero me quedo una duda sobre como se aplica ...

            if (BandConverFechaProceso == true && fechaArchivo != fechaProceso)
            {
                rechazos.AppendLine("Fecha proceso incorrecta"); //AppendLine es un metodo de StringBuilder que agrega una nueva linea al final del contenido actual. 
            }

            if (string.IsNullOrEmpty(codigoVendedorLine)) // .IsNullOrEmpty es un metodo de string, que nos devuelve un bool en "true" si el contenido del string es null, o tiene cero longitud de caracteres de lo contrario devuelve false 
            {
                rechazos.AppendLine("Codigo de vendedor ausente o incorrecto");
            }

            if (!marcaGrande.Contains(empresaGrande)) // .Contains es un metodo de string que "consulta" si hay una cadena especifica dentro de otra, si es asi devuelve un true, de lo contrario un false. 
            {
                rechazos.AppendLine("Marca de empresa grande incorrecta");
            }

            if (string.IsNullOrEmpty(rechazos.ToString()))
            {
                return null;
            }

            var CargaDatosRechazados = new Rechazos() //instanciamos rechazos, lo asignamos a una variable, y a su prop "Motivos" le asignamos lo que fuimos guardando en rechazos. 
            {
                Motivos = rechazos.ToString()
            };

            return CargaDatosRechazados;

        }


        private static VentasMensuales CargaVentasMensuales(string data)
        {
            string fechaProcesoLine = data.Substring(0, 8).Trim();
            string codigoVendedorLine = data.Substring(8, 3).Trim();
            string ventaLine = data.Substring(11, 11).Trim();
            string empresaGrande = data.Substring(22, 1).Trim();

            DateTime fechaProceso = DateTime.ParseExact(fechaProcesoLine, "yyyyMMdd", CultureInfo.InvariantCulture);

            decimal mVenta = decimal.Parse(ventaLine, CultureInfo.InvariantCulture);

            return new VentasMensuales()
            {
                FechaInforme = fechaProceso,
                CodigoVendedor = codigoVendedorLine,
                Venta = mVenta,
                VentaGrande = empresaGrande == "S" // el == "S" es una exprecion de igualdad, por eso la prop es bool, por que devuelve un tru o un false. si contiene "S" es true, de lo contrario false. 
            };
        }
    }
}
