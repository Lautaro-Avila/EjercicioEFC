using EjercicioIFC.Repository.Domain.Entities;


namespace EjercicioIFC
{
    public class ConsultasBD
    {

        public static void realizarConsultasBD(DatabaseContext context)
        {
            var listaVendedoresMayores = context.VentasMensuales.GroupBy(group => group.CodigoVendedor)
                                                                       .Where(where => where.ToList().Sum(sum => sum.Venta) >= 100000m)
                                                                       .Select(select => new { select.Key, Totalventa = select.ToList().Sum(select => select.Venta) }).ToList();

            if (listaVendedoresMayores.Count() > 0)
            {
                listaVendedoresMayores.ForEach(venta => Console.WriteLine($"El vededor {venta.Key} vendio {venta.Totalventa}"));
            }



            var listVendedoresMenores = context.VentasMensuales.GroupBy(group => group.CodigoVendedor)
                                                               .Where(where => where.ToList().Sum(sum => sum.Venta) <= 100000m)
                                                               .Select(select => new { select.Key, Totalventa = select.ToList().Sum(select => select.Venta) }).ToList();

            if (listVendedoresMenores.Count() > 0)
            {
                listVendedoresMenores.ForEach(venta => Console.WriteLine($"El vededor {venta.Key} vendio {venta.Totalventa}"));
            }


            var ventasMarcaEmpresa = context.VentasMensuales.GroupBy(group => group.CodigoVendedor)
                                                             .Where(where => where.ToList().Any(any => any.VentaGrande))
                                                             .Select(select => new { select.Key, TotalVenta = select.ToList().Sum(sum => sum.Venta) }).ToList();


            if (ventasMarcaEmpresa.Count() > 0)
            {
                ventasMarcaEmpresa.ForEach(marca => Console.WriteLine($"{marca.Key}"));
            }

            //Mostrar el promedio de ventas por los empleados 

            var promedioVentas = context.VentasMensuales.GroupBy(group => group.CodigoVendedor)
                                                        .Select(select => new { select.Key, Promedio = select.ToList().Average(average => average.Venta) }).ToList();

            if (promedioVentas.Count() > 0)
            {
                promedioVentas.ForEach(promedio => Console.WriteLine($"El promedio de ventas del vendedor {promedio.Key} es {promedio.Promedio}"));
            }
    
            //Listar cantidad de ventas por vendedor
        var cantidadVendedores = context.VentasMensuales.GroupBy(group => group.CodigoVendedor)
                                                        .Select(select => new { select.Key, Cantidad = select.ToList().Count() }).ToList();

        if (cantidadVendedores.Count() > 0)
            {
            cantidadVendedores.ForEach(cantidad => Console.WriteLine($"El vendedor {cantidad.Key} tiene {cantidad.Cantidad} ventas"));
        }
         //Total de ventas por vendedor
        var ventasPorVendedor = context.VentasMensuales.GroupBy(group => group.CodigoVendedor)
                                                        .Select(select => new { select.Key, TotalVenta = select.ToList().Sum(sum => sum.Venta) }).ToList();

            if (ventasPorVendedor.Count() > 0)
            {
                ventasPorVendedor.ForEach(venta => Console.WriteLine($"El vendedor {venta.Key} vendio {venta.TotalVenta}"));
            }

       }
    }
}
