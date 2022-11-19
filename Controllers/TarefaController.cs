using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using agendadev_mvc.Context;

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
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null) 
            {
                return NotFound();
            }

            return View(tarefa);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }
    }
}