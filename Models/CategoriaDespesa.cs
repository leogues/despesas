using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Despesas.Models
{
  [Table(name: "CategoriaDespesa")]
  public class CategoriaDespesa
  {
    public int Id { set; get; }

    [MaxLength(150)]
    [Required(ErrorMessage = "Informe o campo Descrição")]
    public string Descricao { set; get; }

    public virtual ICollection<Despesa> Despesas { set; get; }
  }
}