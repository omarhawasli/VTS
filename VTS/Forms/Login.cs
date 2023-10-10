using System;
using System.Data;
using System.Windows.Forms;
using VTS.Models;
using System.Data.SqlClient;
using MySqlConnector;

namespace VTS
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
            DB.connect();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter username");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter password");

            }
            else
            {
                try
                {

                    
                    string query = "SELECT * from login WHERE username= @username AND password=@password;";

                    DB.cmd = new MySqlCommand(query, DB.connection);

                   
                    DB.cmd.Parameters.AddWithValue("@username",textBox1.Text);
                    DB.cmd.Parameters.AddWithValue("@password",textBox2.Text);
                    
                    MySqlDataAdapter adapter = new MySqlDataAdapter(DB.cmd);
                    DataTable dt = new DataTable();
                    
                    adapter.Fill(dt);
                    
                    if (dt.Rows.Count > 0)
                    {
                        MainMenu main = new MainMenu();
                        main.Show();
                        this.Hide();
                        // MessageBox.Show("Login Successfull");
                    }
                    else
                    {
                        MessageBox.Show("username or password is invalid");
                    
                    }
                    
                }
                catch (Exception exception){
                    MessageBox.Show(exception.Message);
                    throw;
                }
            }


        }
        
    }
}