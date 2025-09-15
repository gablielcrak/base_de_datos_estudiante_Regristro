using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace base_de_datos_estudiante_Regristro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source = JOSE\\SQLEXPRESS; Initial Catalog = TU_BASE_DE_DATOS; User ID = merliajos; Password = 132456;");
            conexion.Open();
            string nom = txtNombre.Text;
            string apell = txtApellido.Text;
            string año = txtEdad.Text;
            string sex = txtSexo.Text;
            string email = txtCorreo.Text;
            string cadena = "insert into TB_Estudiante(Nombre_Estudiante,Apellido_Estudiante,Edad,Sexo,Correo_Estudiante)values('" + nom + "','" + apell + "','" + año + "','" + sex + "', '" + email + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaro correctamente");
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtSexo.Text = "";
            txtCorreo.Text = "";
            conexion.Close();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=JOSE\\SQLEXPRESS;database=BD_RegistroEstudiante;integrated security=true");
            conexion.Open();
            string cadena = "select Id_Estudiante,Nombre_Estudiante,Apellido_Estudiante,Edad,Sexo,Correo_Estudiante from dbo.TB_Estudiante";
            SqlCommand comado = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comado.ExecuteReader();
            while (registro.Read())
            {
                textregistro.AppendText(registro["Id_Estudiante"].ToString());
                textregistro.AppendText(" - ");
                textregistro.AppendText(registro["Nombre_Estudiante"].ToString());
                textregistro.AppendText(" - ");
                textregistro.AppendText(registro["Apellido_Estudiante"].ToString());
                textregistro.AppendText(" - ");
                textregistro.AppendText(registro["Edad"].ToString());
                textregistro.AppendText(" - ");
                textregistro.AppendText(registro["Sexo"].ToString());
                textregistro.AppendText(" - ");
                textregistro.AppendText(registro["Correo_Estudiante"].ToString());
                textregistro.AppendText(" - ");
                textregistro.AppendText(Environment.NewLine);
            }
            conexion.Close();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=JOSE\\SQLEXPRESS;database=BD_RegistroEstudiante;integrated security=true");
            conexion.Open();
            string cod = txtBuscar.Text;
            string cadena = "select Nombre_Estudiante,Apellido_Estudiante,Edad,Sexo,Correo_Estudiante from TB_Estudiante where Id_Estudiante=" + cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtNombre.Text = registro["Nombre_Estudiante"].ToString();
                txtApellido.Text = registro["Apellido_Estudiante"].ToString();
                txtEdad.Text = registro["Edad"].ToString();
                txtSexo.Text = registro["Sexo"].ToString();
                txtCorreo.Text = registro["Correo_Estudiante"].ToString();
            }
            else
            {
                MessageBox.Show("No existe el registro", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=JOSE\\SQLEXPRESS;database=BD_RegistroEstudiante;integrated security=true");
            conexion.Open();
            string cod = txtBuscar.Text;
            string nomb = txtNombre.Text;
            string apell = txtApellido.Text;
            string año = txtEdad.Text;
            string sex = txtSexo.Text;
            string email = txtCorreo.Text;
            string cadena = "update TB_Estudiante set Nombre_Estudiante = '" + nomb + "',Apellido_Estudiante = '" + apell + "',Edad = '" + año + "',Sexo = '" + sex + "',Correo_Estudiante ='" + email + "' where Id_Estudiante=" + cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Datos Modificado correctamente", "Datos Modificado incorrectamente");
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                txtSexo.Text = "";
                txtCorreo.Text = "";
                txtBuscar.Text = "";
            }
            else
            {
                MessageBox.Show("No existe este datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                btnActualizar.Enabled = false;
            }
        }
    }
}
