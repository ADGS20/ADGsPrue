using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    /// <summary>
    /// Reglas del juego:
    /// - Fase 1: QuienEmpieza, ColorContrario
    /// - Fase 2: PuedePoner, CuantasSeguidas
    /// - Fase 3: TableroInicial, Gana
    /// </summary>
    public class Reglas
    {
        // — Fase 1 —

        /// <summary> Devuelve el color que empieza: AMARILLA. </summary>
        public TipoCasilla QuienEmpieza() => TipoCasilla.AMARILLA;

        /// <summary>
        /// Dado un color, devuelve el contrario:
        /// ROJA ↔ AMARILLA, VACIA → VACIA.
        /// </summary>
        public TipoCasilla ColorContrario(TipoCasilla actual)
        {
            if (actual == TipoCasilla.ROJA) return TipoCasilla.AMARILLA;
            if (actual == TipoCasilla.AMARILLA) return TipoCasilla.ROJA;
            return TipoCasilla.VACIA;
        }

        // — Fase 2 —

        /// <summary>
        /// True si la columna está en [0..Columnas-1]
        /// y la casilla superior (y=Filas-1) está VACIA.
        /// </summary>
        public bool PuedePoner(Tablero tablero, int columna)
        {
            if (columna < 0 || columna >= tablero.Columnas)
                return false;
            return tablero.GetCasilla(columna, tablero.Filas - 1) == TipoCasilla.VACIA;
        }

        /// <summary>
        /// Cuenta cuántas fichas seguidas del mismo color hay,
        /// partiendo en (x,y) y avanzando en (dx,dy).
        /// Si arranca en VACIA → 0.
        /// </summary>
        public int CuantasSeguidas(Tablero tablero, int x, int y, int dx, int dy)
        {
            var color = tablero.GetCasilla(x, y);
            if (color == TipoCasilla.VACIA) return 0;

            int cuenta = 0;
            while (x >= 0 && x < tablero.Columnas && y >= 0 && y < tablero.Filas
                   && tablero.GetCasilla(x, y) == color)
            {
                cuenta++;
                x += dx;
                y += dy;
            }
            return cuenta;
        }

        // — Fase 3 —

        /// <summary> Devuelve un Tablero vacío por defecto. </summary>
        public Tablero TableroInicial() => new Tablero();

        /// <summary>
        /// Comprueba si 'turno' ha logrado 4 en raya
        /// (horiz., vert. o diag.) en 'tablero'.
        /// </summary>
        public bool Gana(Tablero tablero, TipoCasilla turno)
        {
            for (int y = 0; y < tablero.Filas; y++)
                for (int x = 0; x < tablero.Columnas; x++)
                {
                    if (tablero.GetCasilla(x, y) != turno)
                        continue;
                    if (CuantasSeguidas(tablero, x, y, 1, 0) >= 4) return true;
                    if (CuantasSeguidas(tablero, x, y, 0, 1) >= 4) return true;
                    if (CuantasSeguidas(tablero, x, y, 1, 1) >= 4) return true;
                    if (CuantasSeguidas(tablero, x, y, -1, 1) >= 4) return true;
                }
            return false;
        }
    }
}
