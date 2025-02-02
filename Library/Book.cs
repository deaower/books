using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum BookFormat
    {
        None,
        PDF,
        DOCX,
        EPUB,
        MOBI
    }

    internal class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public BookFormat Format { get; set; } // Новое свойство для формата книги

        public Book(string title, string author, int yearPublished, BookFormat format)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            Format = format;
        }

        public override string ToString()
        {
            return $"{Title} - {Author} ({YearPublished}) [{Format}]";
        }
    }
}
