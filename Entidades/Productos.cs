using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        private int _idProducto;
        private string _nombre;
        private string _descripcion;
        private decimal _precio;

        public int idProducto { get => _idProducto; set => _idProducto = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string descripcion { get => _descripcion; set => _descripcion = value; }
        public decimal precio { get => _precio; set => _precio = value; }

    }
}
