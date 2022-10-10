using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_LIB
{
    public class UtilizadorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage ="Digite o seu Username")]
        public string Login { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a Palavra-Passe")]
        public string Password { get; set; }
        //public byte[]? Imagem { get; set; }

        public bool PasswordValida(string password)
        {
            return Password == password;
        }
        public List<FaturaModel> Faturas { get; set; }


    }
}
