using ContatosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatosAPI.Data
{
    public class ContatoContexto : DbContext
    {
        public ContatoContexto(DbContextOptions<ContatoContexto> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
