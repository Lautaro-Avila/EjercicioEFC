using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioIFC.Domain.Entities
{
    //CREAMOS LA CLASE PARA VENTAS MENSUALES
        public class VentasMensuales
    {
        public int Id {  get; set; }
        public DateTime FechaInforme { get; set; }
        public string CodigoVendedor { get; set; }
        public decimal  Venta {  get; set; }
        public bool VentaGrande { get; set; }

    }
}
