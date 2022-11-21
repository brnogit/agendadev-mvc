using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using agendadev_mvc.Context;
using agendadev_mvc.Models;

namespace agendadev_mvc.Controllers
{
    public class TarefaController : Controller
    {
        //carregar as informações do banco de dados da Tarefa em tela// injeção de dependencia
        private readonly TarefaContext _context;

        //construtor
        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }


        [HttpGet]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null) 
            {
                return NotFound();
            }

            return View(tarefa);
        }

        #region Parte de criação
        //Primeira vez que entrar em Criar
        [HttpGet] //opcional colocar o get
        public IActionResult Criar()
        {
            return View();
        }

        // Preenchi as informações e cliquei em Criar, vai chamar o POST e trazer o metodo abaixo
        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (ModelState.IsValid) //se os dados estiverem validos
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(ObterTodos)); //volta para a tela de ObterTodos
            }
            return View(tarefa); // se não for valido, retorna para a mesma pagina. Exibindo os erros
        }
        #endregion

        #region Parte de Atualização
        [HttpGet]
        public IActionResult Atualizar(int id) // recebo como parametro o int id pois vou atualizar a tarefa
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
            {
                return RedirectToAction(nameof(ObterTodos));
            }

            return View(tarefa);
        }
        #endregion

    }
}