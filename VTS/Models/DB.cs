using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace VTS.Models
{
    public class DB
    {
        public static string aktuellesLand;

        public static string connectionString = "datasource=localhost;" +
                                                "username=root;" +
                                                "password=;" +
                                                "database=vts;";
        
        public static MySqlConnection connection;
        public static MySqlCommand cmd = null;
        
        public static DataSet dataset;
        public static DataTable dt;
        public static MySqlDataAdapter adapter;
        
        

        public static void connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                // MessageBox.Show("erfolgreich");
            }
            catch (Exception e)
            {
                MessageBox.Show(text:e.Message,"Fehler",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
        }


        public static DataSet ReadTickets()
        {
            try
            {
                string query = "SELECT * FROM ticket WHERE land=@land;";
                
                cmd = new MySqlCommand(query, connection);
                
                cmd.Parameters.AddWithValue("@land",aktuellesLand);
                // MessageBox.Show("secssus");
                // MessageBox.Show(aktuellesLand);

                adapter = new MySqlDataAdapter(cmd);
                dataset = new DataSet();
                adapter.Fill(dataset);
            
                return dataset;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
        }
        
        
        
        public static DataSet ReadKonzerten()
        {
            try
            {
                
                string query = "SELECT * FROM konzerten;";

                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@land",aktuellesLand);
                
                adapter = new MySqlDataAdapter(cmd);
                dataset = new DataSet();
                adapter.Fill(dataset);
            
                return dataset;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return null;
        }
        
        
        
        public static DataSet Read()
        {
            try
            {
                
                string query = "SELECT * FROM konzerten WHERE landname=@land;";

                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@land",aktuellesLand);
                
                adapter = new MySqlDataAdapter(cmd);
                dataset = new DataSet();
                adapter.Fill(dataset);
            
                return dataset;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return null;
        }
        
        
        public static void Create(Ticket neuenTicket)
        {
            try
            {
                string query = "INSERT INTO ticket(vorname,nachname,preis,platz,reihe,land) " +
                                   "VALUES(@vorname,@nachname,@preis,@platz,@reihe,@land);";

                cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@vorname", neuenTicket.Vorname);
                cmd.Parameters.AddWithValue("@nachname", neuenTicket.Nachname);
                cmd.Parameters.AddWithValue("@preis", neuenTicket.Preis);
                cmd.Parameters.AddWithValue("@platz", neuenTicket.Platz);
                cmd.Parameters.AddWithValue("@reihe", neuenTicket.Reihe);
                cmd.Parameters.AddWithValue("@land", neuenTicket.Land);


                cmd.ExecuteNonQuery(); 
                

               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        
        
        
    }
}