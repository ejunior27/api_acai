using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    
    public class AdicionalPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int AdicionalId { get; set; }
    }
}
