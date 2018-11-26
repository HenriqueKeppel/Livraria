using System;

namespace Livraria.Domain.Models
{
    public class Critica
    {
        public int Id {get;set;}
        public string Isbn {get;set;}
        public string Autor {get;set;}
        public string Descricao {get;set;}
    }
}