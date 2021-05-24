using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace basededatosMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda";

        private void btnregistrarU_Click(object sender, EventArgs e)
        {
            
            try
            {
                //string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda";
                string cadena = "insert into usuarios(id,nombre,apellidos,direccion)values(NULL,'" + txtnombres.Text + "','" + txtapellidos.Text + "','" + txtdireccion.Text + "')";

                MySqlConnection databaseCon = new MySqlConnection(conexion);

                MySqlCommand comando = new MySqlCommand(cadena, databaseCon);

                databaseCon.Open();
                MySqlDataReader reader = comando.ExecuteReader();
                MessageBox.Show("Usuario insertado correctamente");
                databaseCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnmostrarU_Click(object sender, EventArgs e)
        {
            try
            {
                //string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda";
                string cadena = "select*from usuarios";
                MySqlConnection databaseCon = new MySqlConnection(conexion);

                MySqlCommand comando = new MySqlCommand(cadena, databaseCon);

                databaseCon.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                //si se encontraron datos
                if (reader.Read())
                {
                    while (reader.HasRows)
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var listviewitem = new ListViewItem(row);
                        listView1.Items.Add(listviewitem);
                    }

                }
                else
                {
                    MessageBox.Show("No se encontraron datos");
                }

                databaseCon.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            string cadena = " update usuarios set nombres=, apellidos=, ";





        }
    }
}
