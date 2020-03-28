using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    public class AcaiContext : DbContext
    {
        public AcaiContext(DbContextOptions<AcaiContext>
        options) : base(options)
        {
        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Sabor> Sabor { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<AdicionalPedido> AdicionaisPedidos { get; set; }
        
    }
}
