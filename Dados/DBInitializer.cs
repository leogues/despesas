using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Despesas.Models;

namespace Despesas.Dados
{
    public class DBInitializer
    {
        public static void Initialize(Context context)
        {
            if (context.Database.EnsureCreated())
            {
                //Criar usuário admin
                context.Usuarios.Add(
                    new Usuario {
                        Nome = "Administrador", 
                        Login = "admin", 
                        Senha = "123" 
                    });

                // //Cria Estruturas
                // context.Estruturas.Add(new Estrutura
                // {
                //     Nome = "Área Comum",
                //     Descricao = "Área ampla, climatizada e confortável.",
                //     Imagem = "area_comum.jpg"
                // });

                // context.Estruturas.Add(new Estrutura
                // {
                //     Nome = "Área kids",
                //     Descricao = "Área kids com brinquedos seguros e confortáveis.",
                //     Imagem = "area_kids.jpg"
                // });

                // //Categorias
                // var cafe = new Categoria{Nome = "Café"};
                // var refrigerante = new Categoria{Nome = "Refrigerante"};
                // var lanche = new Categoria{Nome = "Lanche Natural"};
                // context.Categorias.Add(cafe);
                // context.Categorias.Add(refrigerante);
                // context.Categorias.Add(lanche);

                // //Alimentos
                // context.Alimentos.Add(
                //     new Alimento { 
                //         Nome = "Café Curto", 
                //         Descricao = "O café curto é aquele feito em máquinas de café expresso e tem entre 25 e 35 ml.", 
                //         Categoria = cafe, 
                //         Imagem = "cafe_curto.jpg" }
                //     );
                // context.Alimentos.Add(new Alimento { Nome = "Café Longo", Descricao = "O café longo, como o próprio nome já diz, é maior do que o café curto.", Categoria = cafe, Imagem = "cafe_longo.jpg" });
                // context.Alimentos.Add(new Alimento { Nome = "Cappuccino", Descricao = "Cappuccino, do italiano, pronunciado: ou capuchino, geralmente pronunciado.", Categoria = cafe, Imagem = "capuchino.jpg" });
                // context.Alimentos.Add(new Alimento { Nome = "Macchiato", Descricao = "Um macchiato é uma bebida à base de café expresso e espuma.", Categoria = cafe, Imagem = "macchiato.jpg" });
                // context.Alimentos.Add(new Alimento { Nome = "Refrigerante de Cola", Descricao = "Refrigerante a base de cola da marca Pepsi", Categoria = refrigerante, Imagem = "bebida_cola.jpg" });
                // context.Alimentos.Add(new Alimento { Nome = "Lanche de Queijo", Descricao = "Queijo Prato, Maionese e Alface", Categoria = lanche, Imagem = "presunto_queijo.jpg" });
                // context.Alimentos.Add(new Alimento { Nome = "Lanche de Peito de Peru", Descricao = "Peito de Peru, Maionese e Alface", Categoria = lanche, Imagem = "peito_peru.jpg" });

                context.SaveChanges();
            }
        }
    }
}
