using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioPedido
    {
        private PedidoRepository pedidoRepository;

        public ServicioPedido(PedidoRepository repo)
        {
            pedidoRepository = repo;
        }

        public ServicioPedido()
        {
        }

        public string RegistrarPedido(string estudiante, string libro)
        {
            if (estudiante == "" || libro == "")
            {
                return "Error: El nombre del estudiante y del libro no pueden estar vacíos.";
            }

            var pedidos = pedidoRepository.ConsultarTodos();
            int nuevoId = pedidos.Any() ? pedidos.Max(p => p.Id) + 1 : 1;

            var nuevoPedido = new Pedido
            {
                Id = nuevoId,
                Estudiante = estudiante,
                Libro = libro,
                Fecha = DateTime.Now
            };

            pedidoRepository.Guardar(nuevoPedido);
            return "Pedido registrado exitosamente.";
        }

        public List<Pedido> ListaPedidos()
        {
            return pedidoRepository.ConsultarTodos();
        }
    }
}