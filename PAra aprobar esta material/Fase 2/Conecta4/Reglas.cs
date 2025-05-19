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
        /// True si la casilla superior (y=5) está VACIA.
        /// </summary>
        public bool PuedePoner(Tablero t, int columna)
        {
            return t.GetCasilla(columna, 5) == TipoCasilla.VACIA;
        }

        /// <summary>
        /// Cuenta cuántas fichas seguidas hay del mismo color,
        /// empezando en (x,y) y avanzando en (dx,dy).
        /// Si arranca en VACIA → devuelve 0.
        /// </summary>
        public int CuantasSeguidas(Tablero tab, int ox, int oy, int incrx, int incry)
        {
            TipoCasilla expected = tab.GetCasilla(ox, oy);
            int ret = 1;

            while (tab.GetCasilla(ox + incrx, oy + incry) == expected) {
                ox += incrx;
                oy += incry;
                ++ret;
            }
            return ret;
        }
    }
}
