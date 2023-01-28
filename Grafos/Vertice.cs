using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Libería agregada, para poder dibujar
using System.Linq;
using System.Text;
using System.Threading.Tasks; // Libería agregada, para el manejo de hilos de ejecución
using System.Windows.Forms; 

namespace Grafos
{
    public partial class Vertice : Form
    {
        public bool control; //variable de control
        public string dato; //el dato que almacenara el vertice
        public Vertice()
        {
            InitializeComponent(); 
            control = false;
            dato = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e) // Cuando se le da click al botón aceptar
        {
            string valor = txtVertice.Text.Trim();
            if ((valor == "") || (valor == " "))                // Si los valores estan vacíos muestra el mensaje
            {
                MessageBox.Show("Debes ingresar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                control = true;
                Hide(); // Oculatar la ventana
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) // Cuando se le da click al botón cancelar
        {
            control = false;
            Hide(); // Oculatar la ventana
        }

        private void Vertice_Load(object sender, EventArgs e)
        {
            txtVertice.Focus(); // Pone el cursor dentro del TextBox
        }
       
        private void Vertice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Vertice_Shown(object sender, EventArgs e) // Cuando se muestra el vertice 
        {
            txtVertice.Clear(); // Limpiar el TextBox
            txtVertice.Focus(); // Pone el cursos dentro del TextBox
        }

        private void txtVertice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }
    }
}
