using System;
using System.Collections.Generic;

namespace Criticas.Domain.Models
{
    public class ItemCritica
    {
        public int Id {get;set;}
        public string Isbn {get;set;}
        public string Autor {get;set;}
        public string Descricao {get;set;}
    }
}