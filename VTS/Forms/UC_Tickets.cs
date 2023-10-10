using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using VTS.Models;

namespace VTS
{
    public partial class UC_Tickets : UserControl
    {
        public UC_Tickets()
        {
            InitializeComponent();
            dataGridView.DataSource = DB.ReadTickets().Tables[0];

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


        // public void BindData()
        // {
        //     try
        //     {
        //         string query = "SELECT * FROM tickets WHERE land=@land";
        //         DB.cmd = new MySqlCommand(query, DB.connection);
        //         DB.cmd.Parameters.AddWithValue("@land",DB.aktuellesLand);
        //         
        //         DB.cmd.ExecuteNonQuery();
        //
        //
        //         if (DB.aktuellesLand == "germany")
        //         {
        //             UC_Germany germany = new UC_Germany();
        //             ShowForm(germany);
        //         }
        //         else if(DB.aktuellesLand == "italy")
        //         {
        //             UC_Italy italy = new UC_Italy();
        //             ShowForm(italy);
        //         }
        //         else
        //         {
        //             UC_USA usa = new UC_USA();
        //             ShowForm(usa);
        //         }
        //
        //     }
        //     catch (Exception e)
        //     {
        //         MessageBox.Show(e.Message);
        //         throw;
        //     }
        //
        // }

        
        private void button1_Click(object sender, EventArgs e)
        {
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


        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];  
                
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string vorname = Convert.ToString(selectedRow.Cells["vorname"].Value);
                string nachname = Convert.ToString(selectedRow.Cells["nachname"].Value);
                int platz = Convert.ToInt32(selectedRow.Cells["platz"].Value);
                double preis = Convert.ToDouble(selectedRow.Cells["preis"].Value);
                string reihe = Convert.ToString(selectedRow.Cells["reihe"].Value);

                Ticket ticketToUpdate = new Ticket(id,vorname,nachname,preis,platz,reihe);

                UC_UpdateTicket.ticketToUpdate = ticketToUpdate;
                
                MainMenu.Instance.ShowForm(new UC_UpdateTicket());
            }        
        }


        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];  
                
                string query = "DELETE  FROM ticket WHERE id= @id;";
                DB.cmd = new MySqlCommand(query, DB.connection);
                
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                DB.cmd.Parameters.AddWithValue("@id",id);
                
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

        }
    }
}