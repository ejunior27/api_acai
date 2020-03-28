using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    public class PedidoCompleto
    {
        public int PedidoId { get; set; }
        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public List<Adicional> Adicionais { get; set; }
        public decimal ValorTotal { get; set; }
        public int TempoPreparoTotal { get; set; }

    }
}
