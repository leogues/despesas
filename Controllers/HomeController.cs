using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Despesas.Dados;
using Despesas.Models;

namespace Despesas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async  Task<IActionResult> Index()
        {   
            var dataAtual = System.DateTime.Now;
            var dataMesAnterior = System.DateTime.Now.AddMonths(-1);
            var somaGastoMesAtual = _context.Contas
                                    .Where(x => x.Data.Month == dataAtual.Month && x.Data.Year == dataAtual.Year)
                                    .Sum(t => t.Valor);
            var somaGastoMesAnterior = _context.Contas
                                    .Where(x => x.Data.Month == dataMesAnterior.Month && x.Data.Year == dataMesAnterior.Year)
                                    .Sum(t => t.Valor);
            var somaGastoAnual = _context.Contas
                                    .Where(x => x.Data.Year == dataAtual.Year)
                                    .Sum(t => t.Valor);
            var formatadoSomaGastoMesAtual = somaGastoMesAtual.ToString("c");
            var formatadoSomaGastoMesAnterior = somaGastoMesAnterior.ToString("c");
            var formatadoSomaGastoAnual = somaGastoAnual.ToString("c");

            

            ViewBag.gastoMesAnterior = formatadoSomaGastoMesAnterior;
            ViewBag.gastoMesAtual = formatadoSomaGastoMesAtual;
            ViewBag.gastoAnual = formatadoSomaGastoAnual;
            ViewBag.mesAtualMaiorMesAnterior = false;
            if(somaGastoMesAtual > somaGastoMesAnterior){
                ViewBag.mesAtualMaiorMesAnterior = true;
            }

            var Contas = _context.Contas.
                    OrderByDescending(x => x.Data)
                    .ToListAsync();
            return View(await Contas);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
