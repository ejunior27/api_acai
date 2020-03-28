using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    public class Adicional
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorAdicional { get; set; }
        public int TempoAdicional { get; set; }
    }
}
