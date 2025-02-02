using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Library
{
    internal class BookManager
    {
        private List<Book> books;


        public BookManager()
        {
            books = new List<Book>();
        }

        public void AddBook(string title, string author, int yearPublished, BookFormat format)
        {
            var book = new Book(title, author, yearPublished, format);
            books.Add(book);
        }

        public bool RemoveBook(Guid id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                return true;
            }
            return false;
        }

        public List<Book> FindBookByName(string title)
        {
            return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> FindBookByAuthor(string author)
        {
            return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> PrintAllBooks()
        {
            return books;
        }
        public void ImportBooksFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var importedBooks = JsonConvert.DeserializeObject<List<Book>>(json);

                // Проверяем, что importedBooks не равен null
                if (importedBooks != null)
                {
                    books.AddRange(importedBooks);
                }
                else
                {
                    // Здесь можно обработать ситуацию, когда JSON не может быть десериализован в список книг
                    // Например, вы можете выбросить исключение или вывести предупреждение
                    Console.WriteLine("Не удалось импортировать книги: полученный список равен null.");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден: " + filePath);
            }
        
    }

        public void ExportBooksToFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public void ConvertBookFormat(Book book, BookFormat newFormat)
        {
            // Здесь должна быть реализация логики конвертирования
            // Это место, где вы можете использовать внешние библиотеки для конвертации файлов

            // Пример: преобразование книги из формата PDF в DOCX
            if (book.Format == BookFormat.PDF && newFormat == BookFormat.DOCX)
            {
                // Логика конвертации из PDF в DOCX
            }
            else if (book.Format == BookFormat.DOCX && newFormat == BookFormat.PDF)
            {
                // Логика конвертации из DOCX в PDF
            }

            // Обновляем формат книги
            book.Format = newFormat;
        }
    }
}
