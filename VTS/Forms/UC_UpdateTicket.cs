using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using VTS.Models;

namespace VTS
{
    public partial class UC_UpdateTicket : UserControl
    {
        public static Ticket ticketToUpdate;
        
        public UC_UpdateTicket()
        {
            InitializeComponent();
            DB.connect();
            
            if (ticketToUpdate != null)
            {
                labelID.Text = ticketToUpdate.Id.ToString();
                textBox1.Text = ticketToUpdate.Vorname;
                textBox2.Text = ticketToUpdate.Nachname;;
                textBox3.Text = ticketToUpdate.Preis.ToString();
                textBox4.Text = ticketToUpdate.Platz.ToString();
                textBox5.Text = ticketToUpdate.Reihe;
            }
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

            try
            {
                string query = "UPDATE `ticket` SET `vorname`=@vorname,`nachname`=@nachname,`preis`=@preis,`platz`=@platz,`reihe`=@reiher WHERE id=@id;";
                
                DB.cmd = new MySqlCommand(query, DB.connection);
                
                DB.cmd.Parameters.AddWithValue("@id",labelID.Text);
                DB.cmd.Parameters.AddWithValue("@vorname",textBox1.Text);
                DB.cmd.Parameters.AddWithValue("@nachname",textBox2.Text);
                DB.cmd.Parameters.AddWithValue("@preis",textBox3.Text);
                DB.cmd.Parameters.AddWithValue("@platz",textBox4.Text);
                DB.cmd.Parameters.AddWithValue("@reiher",textBox5.Text);
                
                DB.cmd.ExecuteNonQuery();


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
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }


    }
}