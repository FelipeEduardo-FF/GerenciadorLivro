using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Command.Books
{
    public class AddBook : IRequest<Result<int>>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int YearPublication { get; set; }

        public Book ToEntity()
        {
            return new Book(Title, Author, ISBN, YearPublication);
        }
    }
}
