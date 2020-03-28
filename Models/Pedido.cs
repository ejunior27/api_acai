using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    public class Pedido
    {        
        public int Id { get; set; }
        public int TamanhoId { get; set; }
        public int SaborId { get; set; }
    }
}
