using System;
using System.Collections.Generic;

namespace Livro.Domain.Models
{
    public class BookGetResponse
    {
        public string kind {get;set;}
        public int totalItens {get;set;}
        public IEnumerable<Book> items {get;set;}
    }
}