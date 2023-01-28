using System;
using System.Collections.Generic;
using System.Drawing; // Libería agregada, para poder dibujar
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; // Libería agregada, para el manejo de hilos de ejecución

namespace Grafos
{
    class CGrafo
    {
        public List<CVertice> nodos; //Lista de nodos del grafo
        public CGrafo()         //Constructor
        {
            nodos = new List<CVertice>();
        }
        /*----------------Operaciones Basicas---------------*/

        //Constuye un nodo a partir de su valor y lo agrega a la lista de nodos
        public CVertice AgregarVertice(string valor) // Sirve para agregar un vertice en el grafo
        {
            CVertice nodo = new CVertice(valor);
            nodos.Add(nodo);
            return nodo;
        }

        //Agrega un nodo a la lista de nodos del grafo
        public void AgregarVertice(CVertice nuevonodo)
        {
            nodos.Add(nuevonodo);
        }

        public void EliminarVertice(CVertice nuevonodo) //Eliminar un nodo a la lista de nodos del grafo
        {
            nodos.Remove(nuevonodo);
        }

        //Busca un nodo en la lista de nodos del grafo
        public CVertice BuscarVertice(string valor)
        {
            return nodos.Find(v => v.Valor == valor);
        }

        //Crea una arista a partir de los valores de los nodos de origen y de destino
        public bool AgregarArco(string origen, string nDestino, int peso = 1)
        {
            CVertice vOrigen, vnDestino;
            //si alguno de los 2 nodos no existen se activa una excepcion
            if ((vOrigen = nodos.Find(v => v.Valor == origen)) == null)
            {
                throw new Exception("El nodo " + origen + " no existe dentro del grafo");
            }
            if ((vnDestino = nodos.Find(v => v.Valor == nDestino)) == null)
            {
                throw new Exception("El nodo " + nDestino + " no existe dentro del grafo");
            }
            return AgregarArco(vOrigen, vnDestino);
        }

        //Crea la arista a partir de los nodos de origen y destino
        public bool AgregarArco(CVertice origen, CVertice nDestino, int peso = 1)
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null)
            {
                origen.ListaAdyacencia.Add(new CArco(nDestino, peso));
                return true;
            }
            return false;
        }

        public bool EliminarArco(CVertice origen, CVertice nDestino)  //Elimina la arista a partir de los nodos de origen y destino
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) != null)
            {
                var arcoTemp = origen.ListaAdyacencia.Find(v => v.nDestino == nDestino);
                origen.ListaAdyacencia.Remove(arcoTemp);
                return true;
            }
            return false;
        }


        //Metodo para dibujar grafo
        public void DibujarGrafo(Graphics g)
        {
            //dibujar arcos
            foreach (CVertice nodo in nodos)
            {
                nodo.DibujarArco(g);
            }
            //dibujar los vertices
            foreach (CVertice nodo in nodos)
            {
                nodo.DibujarVertice(g);
            }
        }

        //Metodo para detectar si se ha posicionado sobre algun nodo y lo devuelve
        public CVertice DetectarPunto(Point posicionMouse)
        {
            foreach (CVertice nodoActual in nodos)
            {
                if (nodoActual.DetectarPunto(posicionMouse))
                {
                    return nodoActual;
                }
            }
            return null;
        }

        //Metodo para regresar al estado original
        public void ReestablecerGrafo(Graphics g)
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.Color = Color.White;
                nodo.FontColor = Color.Black;
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 1;
                    arco.color = Color.Black;
                }
            }
            DibujarGrafo(g);
        }
    }
}
