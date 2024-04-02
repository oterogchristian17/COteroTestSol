using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WindowsForm
{
    public partial class InformeStarWars : Form
    {
        public InformeStarWars()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            string connetionString = "Data Source =.; Initial Catalog = TestSol; User ID = sa; Password = pass@word1";
            SqlConnection connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "EmployeeData";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            connection.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
