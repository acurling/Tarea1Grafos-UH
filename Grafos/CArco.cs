using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing; // Librería agregada, para poder dibujar

namespace Grafos
{
    class CArco
    {
        //Atributos
        public CVertice nDestino;
        public int peso; //Peso (valor) de cada arco (Arista)

        public float grosor_flecha;
        public Color color;

        //Metodos
        public CArco(CVertice destino) : this(destino, 1) // Constructor de la clase CArco
        {
            this.nDestino = destino;
        }
        public CArco(CVertice destino, int peso) // Sobre carga de constructores
        {
            this.nDestino = destino;
            this.peso = peso;
            this.grosor_flecha = 2;
            this.color = Color.Red;
        }
    }
}
