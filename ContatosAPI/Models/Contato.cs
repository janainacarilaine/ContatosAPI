using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContatosAPI.Models
{
    public class Contato
    {
       
       
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string  Nome { get; set; }
        public string Tipo { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o registro")]
        public string  Registro { get; set; }

       
    }
}
