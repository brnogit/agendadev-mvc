using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agendadev_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace agendadev_mvc.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}