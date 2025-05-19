using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    /// <summary>
    /// Almacena un tablero de 7×6, (0,0) es la esquina inferior izquierda.
    /// </summary>
    public class Tablero
    {
        private readonly int filas = 6;
        private readonly int columnas = 7;
        // Nullable: null = VACIA, valor = ficha puesta
        private readonly TipoCasilla?[,] celdas;

        public Tablero()
        {
            // Al crear, todas las celdas quedan null (VACIA).
            celdas = new TipoCasilla?[filas, columnas];
        }

        /// <summary>
        /// Devuelve el contenido de la casilla (x=columna, y=fila).
        /// Si está fuera de rango, devuelve VACIA.
        /// </summary>
        public TipoCasilla GetCasilla(int x, int y)
        {
            if (x < 0 || x >= columnas || y < 0 || y >= filas)
                return TipoCasilla.VACIA;
            // Si es null, interpretamos como VACIA
            return celdas[y, x] ?? TipoCasilla.VACIA;
        }

        /// <summary>
        /// Coloca una ficha en la posición (x,y) sin gravedad.
        /// - Si está fuera de rango, no hace nada (no lanza).
        /// - Si ya había ficha o color==VACIA, no hace nada.
        /// </summary>
        public void ColocaFicha(int x, int y, TipoCasilla color)
        {
            if (x < 0 || x >= columnas || y < 0 || y >= filas)
                return;
            if (color == TipoCasilla.VACIA || celdas[y, x].HasValue)
                return;
            celdas[y, x] = color;
        }

        /// <summary>
        /// Deja caer la ficha en la columna x:
        /// - Si cabe (hay al menos un hueco), la coloca en la primera fila libre (y=0,1,2…)
        ///   y devuelve true.
        /// - Si está llena o x fuera de rango o color==VACIA, devuelve false.
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
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Recorre TODO el array; si alguna celda sigue null => VACIA, devuelve false;
        /// en caso contrario, true.
        /// </summary>
        public bool TableroCompleto()
        {
            for (int y = 0; y < filas; y++)
                for (int x = 0; x < columnas; x++)
                    if (!celdas[y, x].HasValue)
                        return false;
            return true;
        }


    }
}