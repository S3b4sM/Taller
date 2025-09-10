using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Estudiante { get; set; }
        public string Libro { get; set; }
        public DateTime Fecha { get; set; }
    }
}