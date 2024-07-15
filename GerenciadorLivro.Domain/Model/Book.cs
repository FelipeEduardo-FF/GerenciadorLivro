namespace GerenciadorLivro.Domain.Model
{
    public class Book
    {
        public Book( string title, string author, string iSBN, int yearPublication)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublication = yearPublication;
            Status= StatusBook.available;
        }

        public int Id { get;private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublication { get; private set; }
        public StatusBook Status { get; set; }

        public void Reserve()
        {
            Status = StatusBook.reserved;
        }
        public void MakeAvailable()
        {
            Status = StatusBook.available;  
        }
        public void Delete()
        {
            Status = StatusBook.deleted;
        }

    }
}
