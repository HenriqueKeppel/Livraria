using System;
using System.Collections.Generic;

namespace Livro.Domain.Models
{
    public class LivroItem
    {
        public string Isbn {get;set;}
        public string Titulo {get;set;}
        public string Editora {get;set;}
        public IEnumerable<string> Autores {get;set;}
        public string Descricao {get;set;}
    }
}