using System;
using System.Windows.Forms;
using VTS.Models;

namespace VTS
{
    public partial class UC_USA : UserControl
    {
        public UC_USA()
        {
            InitializeComponent();
            DB.aktuellesLand = "usa";
            dataGridView.DataSource = DB.Read().Tables[0];
            

        }
        
        
        public void ShowForm(UserControl form)
        {
            try
            {
                form.Dock = DockStyle.Fill;
                form.Show();
                panel1.Controls.Add(form);
                form.BringToFront();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UC_CreateTicket create = new UC_CreateTicket();
            ShowForm(create);
            // this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            UC_Tickets tickets = new UC_Tickets();
            ShowForm(tickets);
        }
        
    }
}