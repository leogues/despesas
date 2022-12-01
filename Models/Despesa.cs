using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Despesas.Models
{
  [Table(name: "Despesa")]
  public class Despesa
  {
    public int Id { set; get; }

    [Required(ErrorMessage = "Informe o campo Descrição")]
    public string Descricao { set; get; }

    public virtual ICollection<Conta> Contas { set; get; }

    [Required(ErrorMessage = "Informe o campo Categoria")]
    public int CategoriaDespesaId{set; get;}
    public virtual CategoriaDespesa CategoriaDespesa { set; get; }
  }
}