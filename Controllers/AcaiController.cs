using api_acai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Controllers
{
    [Route("acai")]
    public class AcaiController : Controller
    {
        private readonly AcaiContext _context;

        public AcaiController(AcaiContext context)
        {
            _context = context;
        }        

        [HttpPost]
        [Route("Pedir")]
        public async Task<Pedido> Post([FromBody]Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        [HttpPost]
        [Route("Pedir/Adicionais")]
        public async Task<IActionResult> Post([FromBody]AdicionaisPedido adicionais)
        {
            foreach (int a in adicionais.Adicionais)
            {
                var adicional = new AdicionalPedido()
                {
                    AdicionalId = a,
                    PedidoId = adicionais.PedidoId
                };

                _context.AdicionaisPedidos.Add(adicional);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet]
        [Route("Pedir/Finalizar/{id}")]
        public PedidoCompleto Get(int id)
        {
            var pedido = _context.Pedidos.Where(p => p.Id == id).First();

            var tamanho = _context.Tamanho.Where(t => t.Id == pedido.TamanhoId).First();

            var sabor = _context.Sabor.Where(s => s.Id == pedido.SaborId).First();

            var adicionais = _context.AdicionaisPedidos.Where(a => a.PedidoId == id);

            var adicionaisPedido = new List<Adicional>();

            foreach(AdicionalPedido a in adicionais)
            {
                var ad = _context.Adicionais.Where(x => x.Id == a.Id).First();

                adicionaisPedido.Add(ad);
            }

            var pedidoCompleto = new PedidoCompleto()
            {
                PedidoId = id,
                Tamanho = tamanho,
                Adicionais = adicionaisPedido,
                Sabor = sabor,
                TempoPreparoTotal = tamanho.TempoPreparo + adicionaisPedido.Sum(a => a.TempoAdicional) + sabor.TempoAdicional,
                ValorTotal = tamanho.Valor + adicionaisPedido.Sum(a => a.ValorAdicional)
            };

            return pedidoCompleto;
        }        
    }
}
