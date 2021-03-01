using System;
using System.Collections.Generic;
using System.Text;

namespace CrudMvc.Entitidade
{
    public class PessoaEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string email { get; set; }
        public string Endereco { get; set; }

    }
}
