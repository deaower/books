using DocumentFormat.OpenXml.Spreadsheet;
using ZXing;
using System.Drawing;


namespace Library
{
    public partial class Form1 : Form
    {

        private BookManager bookManager;



        public Form1()
        {
            InitializeComponent();
            bookManager = new BookManager();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            if (int.TryParse(txtYear.Text, out int year) && Enum.TryParse<BookFormat>(cmbFormat.SelectedItem.ToString(), out BookFormat format))
            {
                bookManager.AddBook(title, author, year, format);
                MessageBox.Show("Книга добавлена!");
            }
            else
            {
                MessageBox.Show("Введите корректный год издания и выберите формат.");
            }

            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            cmbFormat.SelectedIndex = -1; // Сбрасываем выбор формата

        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem is Book selectedBook)
            {
                bool success = bookManager.RemoveBook(selectedBook.Id);
                if (success)
                {
                    MessageBox.Show("Книга удалена!");
                    PrintAllBooks();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления.");
            }
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
        }

        private void btnSearchByTitle_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            var results = bookManager.FindBookByName(title);
            DisplayResults(results);
        }

        private void btnSearchByAuthor_Click(object sender, EventArgs e)
        {
            string author = txtAuthor.Text;
            var results = bookManager.FindBookByAuthor(author);
            DisplayResults(results);
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintAllBooks();
        }
        private void PrintAllBooks()
        {
            lstBooks.Items.Clear();
            var allBooks = bookManager.PrintAllBooks();
            foreach (var book in allBooks)
            {
                lstBooks.Items.Add(book);
            }
        }

        private void DisplayResults(List<Book> results)
        {
            lstBooks.Items.Clear();
            foreach (var book in results)
            {
                lstBooks.Items.Add(book);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bookManager.ImportBooksFromFile(openFileDialog.FileName);
                    PrintAllBooks();
                    MessageBox.Show("Книги импортированы!");
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bookManager.ExportBooksToFile(saveFileDialog.FileName);
                    MessageBox.Show("Книги экспортированы!");
                }
            }
        }

        private void btnConvertFormat_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана книга
            if (lstBooks.SelectedItem is Book selectedBook)
            {
                // Проверяем и преобразуем формат
                if (cmbNewFormat.SelectedItem != null && Enum.TryParse<BookFormat>(cmbNewFormat.SelectedItem.ToString(), out BookFormat newFormat))
                {
                    try
                    {
                        // Выполняем конвертацию
                        bookManager.ConvertBookFormat(selectedBook, newFormat);

                        // Уведомляем пользователя о успешной конвертации
                        MessageBox.Show("Формат книги конвертирован!");

                        // Обновляем список книг на экране
                        PrintAllBooks();
                    }
                    catch (Exception ex)
                    {
                        // Обработчик ошибок на случай проблем с конвертацией
                        MessageBox.Show($"Произошла ошибка при конвертации книги: {ex.Message}");
                    }
                }
                else
                {
                    // Если не выбран формат
                    MessageBox.Show("Пожалуйста, выберите формат для конвертации.");
                }
            }
            else
            {
                // Если не выбрана книга
                MessageBox.Show("Выберите книгу для конвертации.");
            }
        }




        public void buttonRoli_Click_1(object sender, EventArgs e)
        {
            Roli Roli = new Roli();
            Roli.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
            this.Hide();
        }

       
    }
}