using System;
using System.Collections.Generic;

namespace FoodBoxApi.Models.Database
{
    public partial class Sucursales
    {
        public Sucursales()
        {
            Productos = new HashSet<Producto>();
        }

        public uint SucursalId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string UbicacionAdc { get; set; } = null!;
        public string Horario { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
