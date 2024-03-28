using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmpleado addEmp = new AddEmpleado();
            addEmp.ShowDialog(); // Shows Form2

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEmpleado empleado = new AddEmpleado();
            Dictionary<string, object> resultado = BusinessLayer.Empleado.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testSolDataSet.GetAllEmpleado' table. You can move, or remove it, as needed.
            this.getAllEmpleadoTableAdapter.Fill(this.testSolDataSet.GetAllEmpleado);

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}