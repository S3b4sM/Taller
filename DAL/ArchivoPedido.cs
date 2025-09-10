using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL;

namespace BLL
{
    public class ArchivoPedido : PedidoRepository
    {
        private string filePath = "pedidos.txt";

        public List<Pedido> ConsultarTodos()
        {
            var pedidos = new List<Pedido>();
            if (!File.Exists(filePath))
            {
                return pedidos;
            }

            StreamReader reader = new StreamReader(filePath);
            string linea;

            while ((linea = reader.ReadLine()) != null)
            {
                var datos = linea.Split('|');
                if (datos.Length == 4)
                {
                    var pedido = new Pedido
                    {
                        Id = int.Parse(datos[0]),
                        Estudiante = datos[1],
                        Libro = datos[2],
                        Fecha = DateTime.Parse(datos[3])
                    };
                    pedidos.Add(pedido);
                }
            }
            reader.Close();
            return pedidos;
        }

        public void Guardar(Pedido pedido)
        {
            var linea = $"{pedido.Id}|{pedido.Estudiante}|{pedido.Libro}|{pedido.Fecha:yyyy-MM-dd HH:mm:ss}";

            StreamWriter writer = new StreamWriter(filePath, true);

            writer.WriteLine(linea);

            writer.Close();
        }
    }
}