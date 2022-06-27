using System;
using System.Collections.Generic;

namespace FoodBoxApi.Models.Database
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public uint CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
