using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_LIB;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLOUD_LIB
{
    public class FaturaModel
    {
        [Key]
        public int FaturaID { get; set; }
        public decimal Total { get; set; }
        public string MoradaEntrega { get; set; } 
        public List<DetalhesFatura> Detalhes { get; set; }
        [ForeignKey("Utilizador")]
        public int ID { get; set; }
        public UtilizadorModel? Utilizador { get; set; }

    }
}
