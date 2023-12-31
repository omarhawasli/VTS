using System;
using System.Windows.Forms;
using VTS.Models;

namespace VTS
{
    public partial class UC_CreateTicket : UserControl
    {
        public UC_CreateTicket()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {   
            
            string vorname = textBox1.Text;
            string nachname = textBox2.Text;
            int platz = Convert.ToInt32(textBox4.Text);
            double preis = Convert.ToDouble(textBox3.Text);
            string reihe = textBox5.Text;
            string land = textBox6.Text;
            land.ToLower();

            Ticket neueTicket = new Ticket(vorname,nachname,preis,platz,reihe,land);
            DB.Create(neueTicket);

            if (DB.aktuellesLand == "germany")
            {
                UC_Germany germany = new UC_Germany();
                ShowForm(germany);
            }
            else if(DB.aktuellesLand == "italy")
            {
                UC_Italy italy = new UC_Italy();
                ShowForm(italy);
            }
            else
            {
                UC_USA usa = new UC_USA();
                ShowForm(usa);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_Germany back = new UC_Germany();
            ShowForm(back);
        }
        
    }
}