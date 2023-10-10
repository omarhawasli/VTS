using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTS.Models;

namespace VTS
{
    public partial class MainMenu : Form
    {
        public static MainMenu Instance;
        public MainMenu()
        {
            InitializeComponent();
            DB.connect();
            Instance = this;

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
        
        private void konzertenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_Konzerten konzerten = new UC_Konzerten();
            ShowForm(konzerten);
        }
        
        private void germanyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            UC_Germany germany = new UC_Germany();
            ShowForm(germany);        
        }

        private void uSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_USA usa = new UC_USA();
            ShowForm(usa);  
        }

        private void italyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_Italy italy = new UC_Italy();
            ShowForm(italy);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();

        }
        
    }
}