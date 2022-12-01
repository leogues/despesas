using Despesas.Dados;
using Despesas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despesas.Controllers
{
    public class LoginController : Controller
    {
        private Context _context;

        public LoginController(Context context) {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(Usuario usuarioModel){
            var LoginValidate = ModelState["Login"];
            var SenhaValidate = ModelState["Senha"];
           
            if ((LoginValidate!=null && !LoginValidate.Errors.Any()) ||
                (SenhaValidate!=null && !SenhaValidate.Errors.Any())){ //Validações estão OK
                string usuario = usuarioModel.Login;
                string senha = usuarioModel.Senha;
                //Busca objeto no banco de dados

                var usuarioObj = _context.Usuarios.Where(linha => 
                        linha.Login.Equals(usuario) &&
                        linha.Senha.Equals(senha)).FirstOrDefault();

                if (usuarioObj != null){
                    //Usuario existente no banco de dados
                    ViewBag.usuarioLogado = usuarioModel.Nome;

                    HttpContext.Session.
                        SetString("IdUsuarioLogado", usuarioObj.Id.ToString());

                    HttpContext.Session.
                        SetString("NomeUsuarioLogado", usuarioObj.Nome.ToString());

                    HttpContext.Session.
                        SetString("UsuarioLogado", usuarioObj.Login.ToString());

                    return RedirectToAction("Index", "Home");
                }
                else{
                    ViewBag.ErrorLogin = "Credenciais inválidas";
                    return View("Index"); 
                }
            }else{ 
                return View("Index"); 
            }
        }
    }
}
