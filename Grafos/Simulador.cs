using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Librería agregada, para poder dibujar
using System.Linq; // Proporciona a las clases e interfaz la capacidad para admitir consultas de tipo LINQ (Language Integrated Query)
using System.Text;
using System.Threading.Tasks; // Librería agregada, para manejo de hilos de ejecución
using System.Windows.Forms;
using System.Drawing.Drawing2D; // Librería agregada, para poder dibujar

namespace Grafos
{
    public partial class Simulador : Form
    {
        private CGrafo grafo;           // instanciamos la clase Cgrago
        private CVertice nuevoNodo;     // instanciamos la clase Cvertice para crear el noto "nuevoNodo"
        private CVertice NodoOrigen;    // instanciamos la clase Cvertice para crear el nodo "NodoOrigen" 
        private CVertice NodoDestino;   // instanciamos la clase Cvertice para cerar el noto "NodoDestino"
        private int var_control = 0;    //la utilizamos para determinar el estado en la pizarra:
                                        // 0: SIn acción, 1: Dibujar arco, 2: Nuevo vértice
                        
        //Variables para el control de ventanas modales
        private Vertice ventanaVertice; // le puse la C 

        private Boolean frMSG = false;

        // Codígo en el constructor del formulario es el siguiente:
        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void Pizarra_Load(object sender, EventArgs e)
        {

        }

        private void nuevoVertice_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();     
            var_control = 2;        // recordemos que es usando para indicar el estado en la pizarra:
                                    // 0: Sin acción, 1: Dibujando arco, 2: Nuevo vértice
        }

        private void EliminarVertice_Click(object sender, EventArgs e) // El menú para eliminar vertice
        {
            frMSG = false;
            var_control = 3;
        }

        private void EliminarArco_Click(object sender, EventArgs e)     // El menú para eliminar Arco
        {
            MessageBox.Show("Recree el arco para poder eliminarlo", "Error Arco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Pizarra_MouseUp(object sender, MouseEventArgs e) // Esto es un activador, cuando el maouse va hacia arriba
        {
            switch (var_control)
            {
                case 1: //Dibujar arco
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        if (grafo.AgregarArco(NodoOrigen, NodoDestino)) //Se procede a crear el arco
                        {
                            int distancia = 0;
                            NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                        }
                        else 
                        {
                            //Se procede a eliminar la arco    
                            if (grafo.EliminarArco(NodoOrigen, NodoDestino)) 
                            {
                                MessageBox.Show("Arco Eliminado", "Eliminar Arco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }                                   
                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    Pizarra.Refresh(); // Refresca la pizarra para que le muestre
                    break;
            }
        }

        private void Pizarra_MouseMove(object sender, MouseEventArgs e) // El evento del mouse hacia abajo
        {
            switch (var_control)
            {
                case 3:

                    NodoOrigen = grafo.DetectarPunto(e.Location);

                    if (NodoOrigen != null)
                    {
                        grafo.EliminarVertice(NodoOrigen);
                        nuevoNodo = null;
                        var_control = 0;
                        Pizarra.Refresh();
                        Cursor = Cursors.Default;
                        MessageBox.Show("Nodo Eliminado", "Eliminar Nodo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        if (!frMSG) 
                        {
                            MessageBox.Show("Selecciona el nodo a Eliminar", "Eliminar Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            frMSG = true;
                        }
                            
                        Cursor = Cursors.WaitCursor;
                        
                    }
                    break;

                case 2: //crear nuevo nodo
                    Cursor = Cursors.Default;
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X; // Es posición donde se dibuja en el eje X
                        int posY = e.Location.Y; // Es posición donde se dibuja en el eje Y
                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                        {
                            posX = nuevoNodo.Dimensiones.Width / 2; // Corresponde al tamañan o las dimensiones
                        }
                        else if (posX > Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                        {
                            posX = Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2;
                        }
                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                        {
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        }
                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2)
                        {
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2;
                        }
                        nuevoNodo.Posicion = new Point(posX, posY);
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics());
                    }
                    break;
                case 1: //dibujar arco
                    Cursor = Cursors.Default;
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    {
                        CustomEndCap = bigArrow
                    },
                    NodoOrigen.Posicion, e.Location);
                    break;
            }
        }

        private void Pizarra_MouseLeave(object sender, EventArgs e) // Cuando el mouse de deja de mover
        {
            Pizarra.Refresh();
        }
        // El código en elos eventos "Paint" y "MouseLeave" del objeto "Panel" es el siguiente:
        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) //si se ha presionado el boton izquierdo del mouse
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1; //recordemos que es usado para indicar el estado en la pizarra
                                     //0: sin accion, 1: Dibujar arco, 2: Nuevo vertice
                }
                if (nuevoNodo != null && NodoOrigen == null )
                {
                    ventanaVertice.Visible = false; // No muestra la ventana vertice del menú
                    ventanaVertice.control = false;
                    grafo.AgregarVertice(nuevoNodo);

                    ventanaVertice.ShowDialog();

                    if (ventanaVertice.control)
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            MessageBox.Show("El nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo", "Error nuevo Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    nuevoNodo = null;
                    var_control = 0;
                    Pizarra.Refresh();
                }

            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)//Si se ha presionado el boton derecho del mouse
            {
                if (var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo " + NodoOrigen.Valor;
                    }
                    else
                    {
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                    }
                }
            }
        }

        private void CMSCrearVertice_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
