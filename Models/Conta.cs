using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Despesas.Models
{
  [Table(name: "Conta")]
  public class Conta
  {
    public int Id { set; get; }

    [Required(ErrorMessage = "Informe o campo Valor")]
    [DataType(DataType.Currency)]
    public float Valor { set; get; }

    [Required(ErrorMessage = "Informe o campo Data")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Data { set; get; }
    
    [Required(ErrorMessage = "O campo Despesa é obrigatório")]
    public int DespesaId{set; get;}

    public virtual Despesa Despesa { set; get; }


  }
}