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
                MessageBox.Show("����� ���������!");
            }
            else
            {
                MessageBox.Show("������� ���������� ��� ������� � �������� ������.");
            }

            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            cmbFormat.SelectedIndex = -1; // ���������� ����� �������

        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem is Book selectedBook)
            {
                bool success = bookManager.RemoveBook(selectedBook.Id);
                if (success)
                {
                    MessageBox.Show("����� �������!");
                    PrintAllBooks();
                }
            }
            else
            {
                MessageBox.Show("�������� ����� ��� ��������.");
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
                    MessageBox.Show("����� �������������!");
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
                    MessageBox.Show("����� ��������������!");
                }
            }
        }

        private void btnConvertFormat_Click(object sender, EventArgs e)
        {
            // ���������, ��� ������� �����
            if (lstBooks.SelectedItem is Book selectedBook)
            {
                // ��������� � ����������� ������
                if (cmbNewFormat.SelectedItem != null && Enum.TryParse<BookFormat>(cmbNewFormat.SelectedItem.ToString(), out BookFormat newFormat))
                {
                    try
                    {
                        // ��������� �����������
                        bookManager.ConvertBookFormat(selectedBook, newFormat);

                        // ���������� ������������ � �������� �����������
                        MessageBox.Show("������ ����� �������������!");

                        // ��������� ������ ���� �� ������
                        PrintAllBooks();
                    }
                    catch (Exception ex)
                    {
                        // ���������� ������ �� ������ ������� � ������������
                        MessageBox.Show($"��������� ������ ��� ����������� �����: {ex.Message}");
                    }
                }
                else
                {
                    // ���� �� ������ ������
                    MessageBox.Show("����������, �������� ������ ��� �����������.");
                }
            }
            else
            {
                // ���� �� ������� �����
                MessageBox.Show("�������� ����� ��� �����������.");
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