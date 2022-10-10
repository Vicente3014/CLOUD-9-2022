using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CLOUD_LIB
{
    public class DetalhesFatura
    {
        public int ID { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("Fatura")]
        public int FaturaID { get; set; }
        public FaturaModel Fatura { get; set; }
        [ForeignKey("Artigo")]
        public int ArtigoID { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco_unit { get; set; }

    }
}
