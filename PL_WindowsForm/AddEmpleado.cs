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
    public partial class AddEmpleado : Form
    {
        public AddEmpleado()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testSolDataSet.Area' table. You can move, or remove it, as needed.
            this.areaTableAdapter.Fill(this.testSolDataSet.Area);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Metodos Obtener Strings
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddEmpleado empleado = new AddEmpleado();

            Dictionary<string, object> resultado = BusinessLayer.Area.GetAll();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusinessLayer.Empleado empleado = new BusinessLayer.Empleado(); 

            Dictionary<string, object> resultado = BusinessLayer.Empleado.Add(empleado);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
