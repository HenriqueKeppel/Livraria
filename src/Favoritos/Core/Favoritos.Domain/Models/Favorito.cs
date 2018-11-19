using System;

namespace Favoritos.Domain.Models
{
    public class Favorito
    {
        public string Titulo {get;set;}
        public string Isbn {get;set;}
        public string IdUsuario {get;set;}
        public DateTime DataInclusao {get;set;}
    }
}