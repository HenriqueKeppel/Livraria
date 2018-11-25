using System;

namespace Favoritos.Domain.Models
{
    public class Favorito
    {
        public string Isbn {get;set;}
        public string IdUsuario {get;set;}
        public DateTime DataInclusao {get;set;}
    }
}