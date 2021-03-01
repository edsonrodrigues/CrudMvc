
using CrudMvc.Entitidade;
using CrudMvc.Models;
using CrudMvc.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMvc.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Contexto _contexto;

        public PessoaController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Pessoas.ToListAsync());
        }

        [HttpGet]
        public ActionResult CriarPessoa()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarPessoa(PessoaEntidade pessoa)
        {

            _contexto.Add(pessoa);
            _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarPessoa(int? Id)
        {
            if (Id != null)
            {
                PessoaEntidade p = _contexto.Pessoas.Find(Id);
                return View(p);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarPessoa(int? Id, PessoaEntidade pessoa)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    _contexto.Update(pessoa);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(pessoa);
                }
            }
            else
            {
                return View(pessoa);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirPessoa(int? Id)
        {
            if (Id != null)
            {
                PessoaEntidade p = _contexto.Pessoas.Find(Id);
                return View(p);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirPessoa(int? Id, PessoaEntidade pessoa)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    _contexto.Remove(pessoa);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else { return View(pessoa); }
            }
            else
            {
                return View(pessoa);
            }
        }


    }
}
