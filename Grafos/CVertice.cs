using System;
using System.Collections.Generic;
using System.Drawing;   // Libería agregada, para poder dibujar
using System.Drawing.Drawing2D; // Libería agregada, para poder dibujar
using System.Linq;
using System.Text;
using System.Threading.Tasks;   // Libería agregada, para el manejo de hilos de ejecución

namespace Grafos
{
    class CVertice
    {               // Atributos
        public string Valor; //Valor que almacena (representa) el nodo
        public string nombre; // lista adyacente del nodo
        public List<CArco> ListaAdyacencia; //lista de adyacencia del nodo
        /*Los diccionarios representan una coleccion de claves y valores. El primer paremetro representa
         el tipo de las claves del diccionario, el segundo, el tipo de los valores del diccionario*/
        Dictionary<string, short> _banderas;
        Dictionary<string, short> _banderas_predeterminado;
                    
        static int size = 35; //tamaño del nodo
        Size dimensiones;
        Color color_nodo; //color definido para el nodo
        Color color_fuente; //color definido para la fuente del nombre del nodo
        Point _posicion; // Donde se dibuja el nodo
        int radio; //Radio del objeto que representa el nodo

        //Propiedades
        public Color Color
        {
            get { return color_nodo; }
            set { color_nodo = value; }
        }

        public Color FontColor
        {
            get { return color_fuente; }
            set { color_fuente = value; }
        }
        public Point Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }
        public Size Dimensiones
        {
            get { return dimensiones; }
            set
            {
                radio = value.Width / 2;
                dimensiones = value;
            }
        }

        //Metodos

        //Constructor de la clase, recibe como parametreo el nombre del nodo (el valor que tendra)
        public CVertice(string Valor)
        {
            this.Valor = Valor;
            this.nombre = "";//cree esta variable para que no me de error en CLista pagina 9
            this.ListaAdyacencia = new List<CArco>(); // Crando una lista de tipo Arco
            this._banderas = new Dictionary<string, short>(); 
            this._banderas_predeterminado = new Dictionary<string, short>();
            this.Color = Color.Green; //definimos el color del nodo
            this.Dimensiones = new Size(size, size); //definimos las dimensiones del circulo
            this.FontColor = Color.White; //Color de la fuente
        }
        public CVertice() : this("") { } //constructor por defecto

        //metodo para dibujar el nodo
        public void DibujarVertice(Graphics g)
        {
            SolidBrush b = new SolidBrush(this.color_nodo); // Sirve para crear el objeto para dibujar

            //definimos donde dibujaremos el nodo
            Rectangle areaNodo = new Rectangle(this._posicion.X - radio, this._posicion.Y - radio, this.dimensiones.Width, this.dimensiones.Height);
            g.FillEllipse(b, areaNodo);
            g.DrawString(this.Valor, new Font("Times New Roman", 14), new SolidBrush(color_fuente), this._posicion.X, this._posicion.Y, new StringFormat()
            {
                Alignment = StringAlignment.Center,   // Lo que esta haciendo es alinear el nodo
                LineAlignment = StringAlignment.Center // Lo que esta haciendo es alinear el nodo
            }
            );
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);
            b.Dispose(); //Para liberar los recursos utilizados por el objeto
        }
        //Metodos para dibujar los arcos
        public void DibujarArco(Graphics g)
        {
            float distancia;
            int difY, difX; // Son los puntos de referencia donde se va a dibujar el arco
            foreach (CArco arco in ListaAdyacencia)
            {
                difX = this.Posicion.X - arco.nDestino.Posicion.X;
                difY = this.Posicion.Y - arco.nDestino.Posicion.Y;

                distancia = (float)Math.Sqrt((difX * difX + difY * difY));

                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;

                g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha)
                {
                    CustomEndCap = bigArrow,
                    Alignment = PenAlignment.Center
                }, _posicion,
                new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia), arco.nDestino.Posicion.Y + (int)(radio * difY / distancia))
                );
                g.DrawString(
                    arco.peso.ToString(),
                    new Font("Times New Roman", 12),
                    new SolidBrush(Color.White),
                    this._posicion.X - (int)((difX / 3)),
                    this._posicion.Y - (int)((difY / 3)),
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    }
                    );
            }
        }

        //Metodo para detectar posiciones en el panel donde se dibuja el nodo
        public bool DetectarPunto(Point p)
        {
            GraphicsPath posicion = new GraphicsPath();
            posicion.AddEllipse(new Rectangle(this._posicion.X - this.dimensiones.Width / 2, this._posicion.Y - this.dimensiones.Height / 2, this.dimensiones.Width, this.dimensiones.Height));
            bool retval = posicion.IsVisible(p);
            posicion.Dispose();
            return retval;
        }
        public string ToString()
        {
            return this.Valor;
        }
    }
}
