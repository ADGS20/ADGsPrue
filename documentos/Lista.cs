using System;

namespace Listas
{
	public class Lista{
		class Nodo{
			public int dato;
			public Nodo sig; // enlace al siguiente nodo

			// constructoras
			public Nodo(int e){ dato = e; sig = null;}
			public Nodo(int e, Nodo n){ 
				dato = e; sig = n;
			}

		}

		// atributos de la lista enlazada: referencia al primero y al último
		Nodo pri, ult;
		public int nElems;


		/// <summary>
        /// Constructora vacía de la lista
        /// </summary>
		public Lista(){
			pri = ult = null;
			nElems = 0;
		}

		//Constructora de una lista 
		//construye una lista enlazada donde cada elemento tiene un valor incremental desde 1 hasta el límite especificado
		
        /*public Lista(int limite, int repeticion)
        {
			//Inicializa los punteros pri (primer elemento y ult (último elemento) a null
            pri = ult = null;
			//Inicializa el número de elementos de la lista en 0
            nElems = 0;
			//Controla el número de repeticiones de la lista enlazada
            for (int r = 0; r < repeticion; r++) {
				//crea los nodos de la lista enlazada
                for (int i = 1; i <= limite; i++) {
					//Si es el primer nodo, crea un nuevo nodo con valor 1, y asigna pri y ult apuntando a ese nodo
                    if (pri == null)
                    {
                        pri = new Nodo(i);
                        pri.sig = null;
                        ult = pri;
                    }
					// Si no es el primer elemento, crea un nuevo nodo y lo enlaza al final de la lista.
                    else
                    {                        
                        ult.sig = new Nodo(i); // Crea un nuevo nodo y lo asigna como siguiente del último nodo.
                        ult = ult.sig;//mueve el puntero ult al nuevo nodo.
                        ult.sig = null;// Establece el siguiente del último nodo como nulo.
                    }
                    nElems++; // Incrementa el contador de elementos en la lista.
                }
            }
        }*/
		

        /// <summary>
        /// Devuelve el número de elementos contenidos en la lista
        /// </summary>
        /// <returns>El número de elementos (0, si está vacía)</returns>
		public int NumEltos(){
			return nElems;
		}

		/// <summary>
		/// Devuelve el elemento que ocupa la n-ésima posición dentro de la lista
		/// </summary>
		/// <param name="n">Posición del elemento a recuperar dentro de la lista</param>
		/// <returns>El elemento en la posición n.</returns>
		/// <exception cref="System.Exception">Lanza una excepción en caso de que no exista la posición n</exception>
		public int N_esimo(int n){
			if (n<0 || n>=nElems) throw new Exception("error n-esimo");
			else {
				Nodo aux = pri;
				while (n>0) { aux = aux.sig; n--;}
				return aux.dato;
			}
		}


		/// <summary>
		/// Obtiene el primer elemento de la lista
		/// </summary>
		/// <param name="e">Parámetro de salida donde se devuelve el primer elemento de la lista.</param>
		/// <exception cref="System.Exception">Lanza una excepción si la lista está vacía</exception>
		public void Primero(out int e){
			if (pri==null) throw new Exception("primero en lista vacia");
			e = pri.dato;
		}


		/// <summary>
		/// Obtiene el ultimo elemento de la lista
		/// </summary>
		/// <param name="e">Parámetro de salida donde se devuelve el último elemento de la lista.</param>
		/// <exception cref="System.Exception">Lanza una excepción si la lista está vacía</exception>
		public void Ultimo(out int e){
			if (ult==null) throw new Exception("ultimo en lista vacia");
			e = ult.dato; 
		}

		
        /// <summary>
        /// Comprueba si un elemento está en la lista
        /// </summary>
        /// <param name="e">Elemento buscado</param>
        /// <returns>True, si el elemento e está en la lista. False, en otro caso</returns>
		public bool Esta(int e){
			Nodo aux= pri;
			// busqueda: avanzazmos con aux mientras no llegemoa al final y no encontremos elto
			while (aux!=null && aux.dato!=e) aux=aux.sig;
			// si no hemos llegado el final, es pq el elto está en la lista
			return (aux!=null);
		}
		

        /// <summary>
        /// Inserta un elemento al principio de la lista
        /// </summary>
        /// <param name="x">Elemento a insertar en la lista</param>
		public void InsertaIni(int x){
			// si la lista es vacia creamos nodo y apuntamos a el pri y ult
			if (pri == null) {
				pri = new Nodo (x);
				pri.sig = null;
				ult = pri;
			} else { // si no es vacia creamos nodo y lo enganchamos al ppio
				Nodo aux = new Nodo(x);
				aux.sig = pri;
				pri = aux;
			}
			nElems++;		
		}


		/// <summary>
		/// Inserta un elemento al final de la lista
		/// </summary>
		/// <param name="x">Elemento a insertar en la lista</param>
		public void InsertaFin(int x){
			// si es vacia creamos nodo y apuntamos a el ppi y ult
			if (pri == null) {
				pri = new Nodo (x);
				pri.sig = null;
				ult = pri;
			} else {
				// si no, creamos nodo apuntado por ult.sig y enlazamos
				ult.sig = new Nodo (x);
				ult = ult.sig;
				ult.sig = null;
			}
			nElems++;
		}
		


		/// <summary>
        /// Borra la primera aparición de un elemento en la lista
        /// </summary>
        /// <param name="x">Elemento buscado</param>
        /// <returns>True, si se ha eliminado el elemento. False, en caso de que el elemento no aparezca en la lista</returns>
		public bool BorraElto(int x){
			// lista vacia
			if (pri==null) return false;
			else {
                bool result = false;
				// eliminar el primero
				if (x == pri.dato) {
                    result = true;
                    nElems--;
					// si solo tienen un elto
					if (pri == ult) 
						pri = ult = null;
					// si tiene más de uno
					else
						pri = pri.sig;
				}
				// eliminar otro distino al primero
				else {
					// busqueda 
					Nodo aux = pri;
					// recorremos lista buscando el ANTERIOR al que hay que eliminar (para poder luego enlazar)
					while (aux.sig != null && x!=aux.sig.dato)                
						aux = aux.sig;
					// si lo encontramos
					if (aux.sig != null) {
                        result = true;
                        nElems--;
						// si es el ultimo cambiamos referencia al ultimo
						if (aux.sig == ult)
							ult = aux;
						// puenteamos
						aux.sig = aux.sig.sig;
					}
				}
                return result;
				
			}
		}

		/// <summary>
		/// Elimina el primer elemento de la lista
		/// </summary>
		/// <exception cref="System.Exception">Lanza una excepción si la lista está vacía</exception>
		public void EliminaIni(){
			if (pri == null)
				throw new Exception ("EliminaIni en lista vacia");
			else if (pri == ult) {
				pri = ult = null;
				nElems--;
			}
			else {
				pri = pri.sig;
				nElems--;
			}
		}
	}


}

