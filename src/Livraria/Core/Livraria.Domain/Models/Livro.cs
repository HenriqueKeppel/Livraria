using System;
using System.Collections.Generic;

namespace Livraria.Domain.Models
{
    public class Livro
    {
        public string Isbn {get;set;}
        public string Titulo {get;set;}
        public string Editora {get;set;}
        public int DataPublicacao {get;set;}
        public string Descricao {get;set;}
        public IEnumerable<string> Autores {get;set;}
        public IEnumerable<Critica> Criticas {get;set;}
        public IEnumerable<Reputacao> Reputacoes {get;set;}
    }
}