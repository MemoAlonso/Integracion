using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DplicacionNomina.DAL;
using DplicacionNomina.BLL;
using System.Configuration;
using System.Data.SqlClient;


namespace DplicacionNomina
{
    public partial class EmpleadoPL : Form
    {
        EmpleadoDAL oempleadosDal;
        EmpleadoBLL oempleadoBll;
        public EmpleadoPL()
        {
            oempleadosDal=new EmpleadoDAL();
            oempleadoBll=new EmpleadoBLL();
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            //ConexionDAL datos = new ConexionDAL();
            //MessageBox.Show("el estado de la conexion es :" + datos.ProbarConexion());
            DialogResult r = MessageBox.Show("¿Estas seguro de registrar la información del empleado?", "Pregunta", MessageBoxButtons.YesNoCancel);
            if(r == DialogResult.Yes) 
            {
                oempleadosDal.AgregarEmpleado(CapturarDatos());
                MessageBox.Show("Información Resgistrada con exito");
                Limpiar();
            
            }
            if(r == DialogResult.No) 
            {
                Limpiar();
            
            }

        }

        private void btSalir_Click(object sender, EventArgs e)
        {   
            if(MessageBox.Show("¿Desea salir de la aplicación?", "Informativo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes) 
            {
                this.Close();
            }
            
        }

        private EmpleadoBLL CapturarDatos() 
        { 
            oempleadoBll.first_name=txtNombre.Text;
            oempleadoBll.birth_date = dtNacimiento.Text;
            oempleadoBll.gender = cmbGenero.Text;
            oempleadoBll.hire_date = dtIngreso.Value;
            return oempleadoBll;

        }

        private void Limpiar() 
        {
           txtNombre.Clear();
           dtNacimiento.Value = DateTime.Now;
           cmbGenero.SelectedIndex = -1;
           dtIngreso.Value = DateTime.Now;

        }  
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
