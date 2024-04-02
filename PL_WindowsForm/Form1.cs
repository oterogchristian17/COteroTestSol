using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            dynamic dato = this.comboBox1.SelectedItem;
            BusinessLayer.Empleado empleado = new BusinessLayer.Empleado();

            empleado.Nombre = this.textBox1.Text;
            empleado.ApellidoPaterno = this.textBox2.Text;
            empleado.ApellidoMaterno = this.textBox3.Text;
            empleado.FechaNacimiento = this.dateTimePicker1.Value;
            
            string sueldo = this.textBox4.Text;
            empleado.Sueldo = Decimal.Parse(sueldo);

            empleado.Area = new BusinessLayer.Area();
            empleado.Area.IdArea = dato.Row.IdArea;

            Dictionary<string, object> resultado = BusinessLayer.Empleado.Add(empleado);

            Modal modal = new Modal();  
            modal.ShowDialog();
            BorrarCampos();

            this.getAllEmpleadoTableAdapter.Fill(this.testSolDataSet.GetAllEmpleado);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testSolDataSet.Area' table. You can move, or remove it, as needed.
            this.areaTableAdapter.Fill(this.testSolDataSet.Area);
            // TODO: This line of code loads data into the 'testSolDataSet.GetAllEmpleado' table. You can move, or remove it, as needed.
            this.getAllEmpleadoTableAdapter.Fill(this.testSolDataSet.GetAllEmpleado);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dynamic dato = this.comboBox1.SelectedItem;
            BusinessLayer.Empleado empleado = new BusinessLayer.Empleado();

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString(); 

            empleado.IdEmpleado = int.Parse(id);    
            empleado.Nombre = this.textBox1.Text;
            empleado.ApellidoPaterno = this.textBox2.Text;
            empleado.ApellidoMaterno = this.textBox3.Text;
            empleado.FechaNacimiento = this.dateTimePicker1.Value;

            string sueldo = this.textBox4.Text;
            empleado.Sueldo = Decimal.Parse(sueldo);

            empleado.Area = new BusinessLayer.Area();
            empleado.Area.IdArea = dato.Row.IdArea;

            Dictionary<string, object> resultado = BusinessLayer.Empleado.Update(empleado);

           
            ModalActualizar actualiza = new ModalActualizar();
            actualiza.ShowDialog();
            BorrarCampos();
            this.getAllEmpleadoTableAdapter.Fill(this.testSolDataSet.GetAllEmpleado);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int idEmpleado = int.Parse(id);

            Dictionary<string, object> resultado = BusinessLayer.Empleado.Delete(idEmpleado);


            ModalEliminar eliminar = new ModalEliminar(); 
            eliminar.ShowDialog();

            BorrarCampos();
            this.getAllEmpleadoTableAdapter.Fill(this.testSolDataSet.GetAllEmpleado);

        }

        private void Actualizar()
        {
            DataSet data = new DataSet();
            data.Tables.Add();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void BorrarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.ResetText();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                DateTime dateValueOftheCell = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                dateTimePicker1.Value = dateValueOftheCell.Date;
                textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            }
            catch { }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}