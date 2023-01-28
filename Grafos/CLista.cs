using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // Libería agregada, para el manejo de hilos de ejecución

namespace Grafos
{
    class CLista
    {
                //Atributos

        private CVertice aElemento;
        private CLista aSubLista;
        private int aPeso;

                //Constructores

        public CLista() 
        {
            aElemento = null;
            aSubLista = null;
            aPeso = 0;
        }
        public CLista(CLista pLista) // Sobre carga de constructores
        {
            if (pLista != null)
            {
                aElemento = pLista.aElemento;
                aSubLista = pLista.aSubLista;
                aPeso = pLista.aPeso;
            }
        }
        public CLista(CVertice pElemento, CLista pSublista, int pPeso) // Sobre carga de constructores
        {
            aElemento = pElemento;
            aSubLista = pSublista;
            aPeso = pPeso;
        }

        //Propiedades

        public CVertice Elemento
        {
            get                     // Para obtener la información
            { return aElemento; }
            set                     // Para settear la información
            { aElemento = value; }
        }
        public CLista SubLista
        {
            get                     // Para obtener la información
            { return aSubLista; }
            set                     // Para settear la información
            { aSubLista = value; }
        }
        public int Peso
        {
            get                     // Para obtener la información
            { return aPeso; }
            set                     // Para settear la información
            { aPeso = value; }
        }

        //Metodos

        public bool EsVacia() //verificar que la lista esta vacia
        {
            return aElemento == null;
        }
        public void Agregar(CVertice pElemento, int pPeso) // Agregar la información a una lista
        {
            if (pElemento != null)
            {
                if (aElemento == null)
                {
                    aElemento = new CVertice(pElemento.nombre); 
                    aPeso = pPeso;
                    aSubLista = new CLista();
                }
                else if (!ExisteElemento(pElemento))
                {
                    aSubLista.Agregar(pElemento, pPeso);
                }
            }
        }
        public void Eliminar(CVertice pElemento)    // Eliminar la información a una lista
        {
            if (aElemento != null)
            {
                if (aElemento.Equals(pElemento))
                {
                    aElemento = aSubLista.aElemento;
                    aSubLista = aSubLista.SubLista;
                }
                else
                {
                    aSubLista.Eliminar(pElemento);
                }
            }
        }
        public int NroElementos()       // Aqui va a ver cuantos elementos hay en la lista
        {
            if (aElemento != null)
            {
                return 1 + aSubLista.NroElementos();
            }
            else
            {
                return 0;
            }
        }
        public object lesimoElemento(int posicion)
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
            {
                if (posicion == 1)
                {
                    return aElemento;
                }
                else
                {
                    return aSubLista.lesimoElemento(posicion - 1); // Aqui hay recursión
                }
            }
            else
            {
                return null;
            }
        }
        public object lesimoElementoPeso(int posicion)
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
            {
                if (posicion == 1)
                {
                    return aPeso;
                }
                else
                {
                    return aSubLista.lesimoElementoPeso(posicion - 1); // Aqui hay recursión
                }
            }
            else
            {
                return 0;
            }
        }
        public bool ExisteElemento(CVertice pElemento) // Verificar si existe el elemento vertice
        {
            if ((aElemento != null) && (pElemento != null))
            {
                return (aElemento.Equals(pElemento) || (aSubLista.ExisteElemento(pElemento)));
            }
            else
            {
                return false;
            }
        }
        public int PosicionElemento(CVertice pElemento) // Ve donde esta la posición del verice
        {
            if ((aElemento != null) || (ExisteElemento(pElemento)))
            {
                if (aElemento.Equals(pElemento))
                {
                    return 1;
                }
                else
                {
                    return 1 + aSubLista.PosicionElemento(pElemento);
                }
            }
            else
            {
                return 0;
            }
        }
    }
        
}
