using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Despesas.Models
{
    [Table(name:"Usuarios")]
    public class Usuario
    {
        public int Id { set; get; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string Nome { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Campo Login é obrigatório")]
        public string Login { set; get; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Senha { set; get; }
    }
}
