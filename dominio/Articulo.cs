using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{   
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Link Imagen")]
        public string imagenurl { get; set; }
        public Categorias Categoria { get; set; }
        public Marca Marca { get; set; }
        public decimal Precio { get; set; } 
  
    }
}
