using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<productos> productos { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Provedores> provedores{ get; set; }
        
    }


    public class productos
    {
        [Key]
        public int productosID { get; set; }
        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public int Cantidad { get; set; }

        public Boolean Disponibilidad { get; set; }

    }


    public class Empleado
    {
        [Key]
        public int empleadoId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string puesto { get; set; }

        [Range(1, 20000)]
        [DataType(DataType.Currency)]
        public decimal sueldo { get; set; }


    }

    public class Provedores
    {
        [Key]
        public int provedorId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string empresa { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string productos { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string contacto { get; set; }


    }





}
