using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    /// <summary>
    /// Define las reglas básicas: quién empieza y cómo alterna el color.
    /// </summary>
    public class Reglas
    {

        // FAse 1

        /// <summary>
        /// Según las reglas del enunciado, siempre empiezan las AMARILLAS.
        /// </summary>
        public TipoCasilla QuienEmpieza()
        {
            return TipoCasilla.AMARILLA;
        }

        /// <summary>
        /// Dado un color actual, devuelve el contrario.
        /// - ROJA → AMARILLA
        /// - AMARILLA → ROJA
        /// - VACIA  → VACIA (por definición en TestNoHaySiguienteAVacia)
        /// </summary>
        public TipoCasilla ColorContrario(TipoCasilla actual)
        {
            if (actual == TipoCasilla.ROJA)
                return TipoCasilla.AMARILLA;
            if (actual == TipoCasilla.AMARILLA)
                return TipoCasilla.ROJA;
            return TipoCasilla.VACIA;
        }

        // FAse 2

        /// <summary>
        /// True si columna ∈ [0..6] y la casilla superior (y=5) está VACIA.
        /// </summary>
        public bool PuedePoner(Tablero tablero, int columna)
        {
            if (columna < 0 || columna > 6)
                return false;
            return tablero.GetCasilla(columna, 5) == TipoCasilla.VACIA;
        }

        /// <summary>
        /// Cuenta cuántas fichas seguidas hay del mismo color,
        /// empezando en (x,y) y avanzando en (dx,dy).
        /// Si arranca en VACIA → devuelve 0.
        /// </summary>
        public int CuantasSeguidas(Tablero tablero, int x, int y, int dx, int dy)
        {
            var color = tablero.GetCasilla(x, y);
            if (color == TipoCasilla.VACIA)
                return 0;

            int cuenta = 0;
            while (x >= 0 && x < 7 && y >= 0 && y < 6
                   && tablero.GetCasilla(x, y) == color)
            {
                cuenta++;
                x += dx;
                y += dy;
            }
            return cuenta;
        }
    }
}
