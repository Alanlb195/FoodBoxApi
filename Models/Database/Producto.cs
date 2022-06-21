using System;
using System.Collections.Generic;

namespace FoodBoxApi.Models.Database
{
    public partial class Producto
    {
        public uint ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public uint SucursalId { get; set; }
        public int Precio { get; set; }
        public uint CategoriaId { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual Categoria Categoria { get; set; } = null!;
        public virtual Sucursales Sucursal { get; set; } = null!;
    }
}
