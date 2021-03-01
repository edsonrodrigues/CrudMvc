using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CrudMvc.Entitidade;


namespace CrudMvc.Models.Context

{
    public class Contexto : DbContext
    {
        public DbSet<PessoaEntidade> Pessoas { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }


    }
}
