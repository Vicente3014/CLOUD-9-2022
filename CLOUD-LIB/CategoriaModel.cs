using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_LIB;

namespace CLOUD_LIB
{
    public class CategoriaModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public ICollection<ArtigoModel> Artigo { get; set; }
    }
}
