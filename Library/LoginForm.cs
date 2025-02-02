using Npgsql;
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
    public partial class LoginForm : Form
    {
       
        public LoginForm()
        {
            
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                bool blnfound = false;
                Connection.conlibrary.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from users where password ='" + txtPassword.Text + "'", Connection.conlibrary);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string username = dr["username"].ToString();
                    Form1 Form1 = new Form1();

                    if (username == "a")
                    {
                        Form1.buttonRoli.Visible = true;
                        
                        MessageBox.Show("Добро пожаловать в систему!", "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Hide();
                        Form1.Show();
                    }
                    else if (username == "u")
                    {
                        Form1.buttonRoli.Visible = false;
                       
                        MessageBox.Show("Добро пожаловать в систему!", "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Hide();
                        Form1.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверный! ", "Вход невозможен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Connection.conlibrary.Close();
                dr.Close();
            }
        }

    }

  }
