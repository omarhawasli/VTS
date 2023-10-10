using System.Windows.Forms;
using VTS.Models;

namespace VTS
{
    public partial class UC_Konzerten : UserControl
    {
        public UC_Konzerten()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.ReadKonzerten().Tables[0];
        }
    }
}