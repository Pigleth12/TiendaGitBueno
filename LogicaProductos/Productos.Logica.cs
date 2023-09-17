using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaProductos
{
    public class ProductosLogica
    {

            private ProductosAccesoDatos _productosAccesoDatos;
            public ProductosLogica()
            {
                _productosAccesoDatos = new ProductosAccesoDatos();
            }
            public List<Productos> ObtenerProductos(string valor)
            {
                return _productosAccesoDatos.ObtenerProductos(valor);
            }
            public void GuardarProductos(Productos nuevosproductos)
            {
                _productosAccesoDatos.GuardarProductos(nuevosproductos);
            }
            public Tuple<bool, string> ValidarProductos(Productos nuevosproductos)
            {
                string mensaje = "";
                bool valida = true;
                if (nuevosproductos.nombre == "")
                {
                    mensaje = mensaje + "El Campo Nombre es Reqerido \n";
                    valida = false;
                }

                if (nuevosproductos.descripcion == "")
                {
                    mensaje = mensaje + "El Campo Descripcion es Reqerido \n";
                    valida = false;
                }

                if (nuevosproductos.precio == 0)
                {
                    mensaje = mensaje + "El Campo Precio es Reqerido \n";
                    valida = false;
                }

                var validar = new Tuple<bool, string>(valida, mensaje);
                return validar;
            }
            public void EliminarProductos(int idProducto)
            {
                _productosAccesoDatos.EliminarProductos(idProducto);
            }
            public void ActualizarProductos(Productos nuevosproductos)
            {
                _productosAccesoDatos.actualizarProductos(nuevosproductos);
            }
        }
}
