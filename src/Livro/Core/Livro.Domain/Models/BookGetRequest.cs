using System;

namespace Livro.Domain.Models
{
    public class BookGetRequest
    {
        public string intitle {get;set;}
        public string inautor {get;set;}
        public string inpublisher {get;set;}
        public string subject {get;set;}
        public string isbn { get;set;}
        public string lccn {get;set;}
        public string oclc {get;set;}
    }
}