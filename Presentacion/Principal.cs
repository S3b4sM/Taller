using BLL;
using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Principal
    {
        private static ServicioPedido pedidoService = new ServicioPedido(new ArchivoPedido());


        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine(" Sistema de Pedidos de Biblioteca");
                Console.WriteLine("1. Registrar un nuevo pedido");
                Console.WriteLine("2. Listar todos los pedidos");
                Console.WriteLine("3. Salir");
                Console.Write("\nSeleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistrarPedido();
                        break;
                    case "2":
                        ListaPedidos();
                        break;
                    case "3":
                        salir = true;
                        break;
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarPedido()
        {
            Console.Clear();
            Console.WriteLine("Registrar Nuevo Pedido");
            Console.Write("Nombre del Estudiante: ");
            string estudiante = Console.ReadLine();

            Console.Write("Nombre del Libro: ");
            string libro = Console.ReadLine();

            string resultado = pedidoService.RegistrarPedido(estudiante, libro);
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private static void ListaPedidos()
        {
            Console.Clear();
            Console.WriteLine("Historial de Pedidos");
            var pedidos = pedidoService.ListaPedidos();

            if (pedidos.Count == 0)
            {
                Console.WriteLine("(No hay pedidos aún)");
            }
            else
            {
                Console.WriteLine("ID | Estudiante | Libro | Fecha");
                Console.WriteLine(new string('-', 50));
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.Id} | {pedido.Estudiante} | {pedido.Libro} | {pedido.Fecha:yyyy-MM-dd HH:mm}");
                }
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
