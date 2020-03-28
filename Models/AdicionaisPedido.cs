using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    public class AdicionaisPedido
    {
        public int PedidoId { get; set; }
        public List<int> Adicionais { get; set; }
    }
}
