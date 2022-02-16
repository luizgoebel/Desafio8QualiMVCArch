using Application.DTOs;
using Application.Interfaces;
using Desafio8QualiMVC.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public int UsuarioId { get; set; }

        public HomeController(IUsuarioService usuarioService, IEmailService emailService, ApplicationDbContext dbContext)
        {
            _usuarioService = usuarioService;
            _emailService = emailService;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _usuarioService.GetUsuarios();
            return View(result);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        /// <summary>
        /// Ao cadastrar um usuário ele cadastra um email na base de usuarios como email principal.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioDTO usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.Add(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        /// <summary>
        /// edição de usuario permite editar o objeto com seu email princial também
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }
            await _usuarioService.Update(usuario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _emailService.GetEmails();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarConfirm(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            await _usuarioService.Remove(usuario.Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarEmail(int id, string email)
        {
            EmailDTO emailDto = new EmailDTO();
            emailDto.UsuarioId = id;
            emailDto.Endereco = email;

            if (emailDto.Endereco != null)
            {
                await _emailService.Add(emailDto);
                return RedirectToAction("Index");
            }
            else
            {
                return View(emailDto);
            }
        }

       
        public async Task<IActionResult> PerfilCompleto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuarioDto = await _usuarioService.GetById(id);

            return View(usuarioDto);
        }



































        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
