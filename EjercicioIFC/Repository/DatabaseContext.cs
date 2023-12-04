using EjercicioIFC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EjercicioIFC.Repository.Domain.Entities;
//2do --- DESPUES DE CREAR LAS CLASES, USAMOS DbContext PARA MAPEAR LOS OBJETOS CREADOS CON LAS TABLAS DE LA DB.

//: hereda de DbContext
public class DatabaseContext : DbContext
{

    //CONFIGURANDO LAS OPCIONES DE LA BASE DE DATOS 

    public DatabaseContext(DbContextOptions<DatabaseContext> options): base (options) 
{

}

    public DbSet<VentasMensuales> VentasMensuales { get; set; }

    public DbSet<Parametria> Parametria { get; set; }

    public DbSet<Rechazos> Rechazos { get; set;}

    //USAMOS EL METODO "OnModelCreating" PARA CONFIGURAR EL MODELO DE DATOS Y LA FORMA DE MAPEAR LA DB Y EL OBJETO DESDE C#
    protected override void OnModelCreating(ModelBuilder modelBuilder) // ---> FIRMA DEL METODO 
    {
        modelBuilder.Entity<VentasMensuales>(entity => //modelBuilder, NOS PERMITE DEFINIR COMO DESDE C# SE TRADUCE A LOS ESQUEMAS DE DB. (SE USA PARA CADA CLASE QUE QUERAMOS TRADUCIR)
        {
            entity.Property(p => p.Id).HasColumnName ("id");
            entity.Property(p => p.FechaInforme).HasColumnName ("fecha_del_informe");
            entity.Property(p => p.CodigoVendedor).HasColumnName("codido_vendedor");
            entity.Property(p => p.Venta).HasColumnName("venta");
            entity.Property(p => p.VentaGrande).HasColumnName("venta_grande");
        });

        modelBuilder.Entity<Parametria>(entity =>
        {
            entity.Property(p => p.Id).HasColumnName("id");
            entity.Property(p => p.Regla).HasColumnName("regla");
            entity.Property(p => p.ValorRegla).HasColumnName("valor_regla");
        });

        modelBuilder.Entity<Rechazos>(entity =>
        {
            entity.Property(p => p.Id).HasColumnName("id");
            entity.Property(p => p.Motivos).HasColumnName("motivos");
        });






            
    }






}