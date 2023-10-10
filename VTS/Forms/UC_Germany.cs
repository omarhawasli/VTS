using System;
using System.Windows.Forms;
using VTS.Models;

namespace VTS
{
    public partial class UC_Germany : UserControl
    {
        public UC_Germany()
        {
            InitializeComponent();
            // DB.connect();
            DB.aktuellesLand = "germany";
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

        private void label3_Click(object sender, EventArgs e)
        {
            UC_CreateTicket create = new UC_CreateTicket();
            ShowForm(create);
            // this.Hide();

        }


        private void label2_Click(object sender, EventArgs e)
        {
            UC_Tickets tickets = new UC_Tickets();
            ShowForm(tickets);
        }
    }
}