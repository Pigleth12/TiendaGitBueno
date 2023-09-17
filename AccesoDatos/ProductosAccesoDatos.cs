using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccesoDatos
{
    public class ProductosAccesoDatos
    {
        Conexion conexion;
        public ProductosAccesoDatos()
        {
            conexion = new Conexion("localhost", "root","", "TiendaGit", 3306);
        }
        public void GuardarProductos(Productos nuevosproductos)
        {
            string consulta = string.Format("INSERT INTO  Productos VALUES(NULL,'{0}','{1}',{2});",
                nuevosproductos.nombre, nuevosproductos.descripcion, nuevosproductos.precio);
            conexion.EjecutarConsulta(consulta);
        }
        public List<Productos> ObtenerProductos(string valor)
        {
            var ListaProductos = new List<Productos>();
            var dt = new DataTable();

            var consulta = string.Format("select * from Productos where nombre like '%{0}%'", valor);

            dt = conexion.ObtenerDatos(consulta);

            foreach (DataRow renglon in dt.Rows) 
            {
                var producto = new Productos
                {
                    idProducto = Convert.ToInt32(renglon["idProducto"]),
                    nombre = renglon["nombre"].ToString(),
                    descripcion = renglon["descripcion"].ToString(),
                    precio = Convert.ToDecimal(renglon["precio"])
                };
                ListaProductos.Add(producto);
            }
            return ListaProductos;
        }
        public void actualizarProductos(Productos nuevosproductos)
        {
            string consulta = string.Format("Update Productos set nombre = '{0}', descripcion = '{1}'," +
                "precio = {2} where idProducto = {3}",
                nuevosproductos.nombre, nuevosproductos.descripcion, nuevosproductos.precio, nuevosproductos.idProducto);
            conexion.EjecutarConsulta(consulta);
        }
        public void EliminarProductos(int idProducto)
        {
            string consulta = string.Format("delete from Productos where idProducto={0}", idProducto);
            conexion.EjecutarConsulta(consulta);
        }
    }
}
