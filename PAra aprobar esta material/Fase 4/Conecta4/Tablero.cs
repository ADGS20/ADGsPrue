using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    /// <summary>
    /// Almacena un tablero dinámico de filas×columnas,
    /// con contador de fichas para TableroCompleto O(1).
    /// (0,0) es la esquina inferior izquierda.
    /// </summary>
    public class Tablero
    {
        private readonly int filas;
        private readonly int columnas;
        // Nullable: null = VACIA, valor = ficha puesta
        private readonly TipoCasilla?[,] celdas;
        // Contador de fichas efectivamente puestas
        private int fichasPuestas;

        /// <summary>
        /// Constructor por defecto: 6 filas × 7 columnas.
        /// </summary>
        public Tablero() : this(6, 7) { }

        /// <summary>
        /// Constructor parametrizado: tablero de tamaño dinámico.
        /// </summary>
        public Tablero(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            celdas = new TipoCasilla?[filas, columnas];
            fichasPuestas = 0;
        }

        /// <summary> Número de filas del tablero. </summary>
        public int Filas => filas;

        /// <summary> Número de columnas del tablero. </summary>
        public int Columnas => columnas;

        /// <summary>
        /// Devuelve el contenido de la casilla (x=columna, y=fila).
        /// Si está fuera de rango, devuelve VACIA.
        /// </summary>
        public TipoCasilla GetCasilla(int x, int y)
        {
            if (x < 0 || x >= columnas || y < 0 || y >= filas)
                return TipoCasilla.VACIA;
            return celdas[y, x] ?? TipoCasilla.VACIA;
        }

        /// <summary>
        /// Coloca una ficha en la posición (x,y) sin gravedad.
        /// Si está fuera de rango, casilla ocupada o color VACIA, no hace nada.
        /// </summary>
        public void ColocaFicha(int x, int y, TipoCasilla color)
        {
            if (x < 0 || x >= columnas || y < 0 || y >= filas) return;
            if (color == TipoCasilla.VACIA || celdas[y, x].HasValue) return;
            celdas[y, x] = color;
            fichasPuestas++;
        }

        /// <summary>
        /// Deja caer la ficha en la columna x:
        /// devuelve true si la coloca en la primera fila libre;
        /// false si columna llena, color VACIA o fuera de rango.
        /// </summary>
        public bool CaeFicha(int x, TipoCasilla color)
        {
            if (x < 0 || x >= columnas || color == TipoCasilla.VACIA)
                return false;

            for (int y = 0; y < filas; y++)
            {
                if (!celdas[y, x].HasValue)
                {
                    celdas[y, x] = color;
                    fichasPuestas++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Comprueba si el tablero está completo comparando el
        /// contador interno de fichas con filas×columnas (O(1)).
        /// </summary>
        public bool TableroCompleto()
        {
            return fichasPuestas == filas * columnas;
        }
    }

}