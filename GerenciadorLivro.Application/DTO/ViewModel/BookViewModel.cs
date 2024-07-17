using GerenciadorLivro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.DTO.ViewModel
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string iSBN, int yearPublication, string status)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublication = yearPublication;
            Status = status;
        }

        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Author { get;  set; }
        public string ISBN { get;  set; }
        public int YearPublication { get;  set; }
        public string Status { get; set; }


        public static BookViewModel FromEntity(Book book)
        {
            return new BookViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.YearPublication,
                book.Status.ToString()
            );
        }
    }
}
