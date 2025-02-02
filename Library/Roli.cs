using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Roli : Form
    {
        private List<User> users;

        public Roli()
        {
            InitializeComponent();
            LoadUsers();

        }
        private void LoadUsers()
        {
            // Пример создания списка пользователей
            users = new List<User>
        {
            new User("u", true, false, true),
            
        };

            dataGridViewUsers.DataSource = users;
        }
        private void Roli_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                // Здесь можно добавить логику сохранения (например, в базу данных или файл)
            }

            MessageBox.Show("Права доступа успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
