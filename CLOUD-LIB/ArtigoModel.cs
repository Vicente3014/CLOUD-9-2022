using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_LIB;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLOUD_LIB
{
    public class ArtigoModel
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        [ForeignKey("Categoria")]
        public int Categoria_ID { get; set; }
        public virtual CategoriaModel Categoria { get; set; }
        public decimal Valor { get; set; }
        public string? Imagem { get; set; }
        public string Descricao { get; set; }

    }
}
