using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultas.Context;
using Microsoft.AspNetCore.Mvc;
using Consultas.Context;
using Consultas.Models;

namespace Consultas.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly ConsultaContext _context;

        public ConsultaController(ConsultaContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var consultas = _context.Consultas.ToList();
            return View(consultas);
        }

        public IActionResult Criar() //Método para entrar na página de criação de consultas
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Consultas.Add(consulta);
                _context.SaveChanges();
                return RedirectToAction(nameof (Index));
            
            }
            return View(consulta);
        }

        public IActionResult Editar(int id) //Retorna a página Editar
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        [HttpPost]
        public IActionResult Editar (Consulta consulta)
        {
            var consultaBanco = _context.Consultas.Find(consulta.Id);

            consultaBanco.Nome = consulta.Nome;
            consultaBanco.Telefone = consulta.Telefone;
            consultaBanco.Profissional = consulta.Profissional;
            consultaBanco.Data = consulta.Data;
            consultaBanco.Sintomas = consulta.Sintomas;

            _context.Consultas.Update(consultaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }   

        public IActionResult Detalhes(int id)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(consulta);
        }  

        public IActionResult Deletar(int id)
        {
             var consulta = _context.Consultas.Find(id);
            if (consulta == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(consulta);
        }   

        [HttpPost]
        public IActionResult Deletar(Consulta consulta)
        {
            var consultaBanco = _context.Consultas.Find(consulta.Id);

            _context.Consultas.Remove(consultaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}