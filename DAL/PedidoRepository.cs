using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace DAL
{
    public interface PedidoRepository
    {
        void Guardar(Pedido pedido);
        List<Pedido> ConsultarTodos();
    }
}
