using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_acai.Models
{
    [Table("Tamanhos")]
    public class Tamanho
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int TempoPreparo { get; set; }
    }
}
