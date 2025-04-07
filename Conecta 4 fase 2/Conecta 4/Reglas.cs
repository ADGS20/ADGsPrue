using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta_4
{
    public class Reglas
    {
        public TipoCasilla QuienEmpieza()
        {
            return TipoCasilla.AMARILLA;
        }
        public TipoCasilla ColorContrario(TipoCasilla color)
        {
            if (color == TipoCasilla.VACIA)
                return TipoCasilla.VACIA;
            else if (color == TipoCasilla.ROJA)
                return TipoCasilla.AMARILLA;
            return TipoCasilla.ROJA;
        }
        public bool PuedePoner(Tablero t, int columna)
        {
            if (columna <0||columna>=7)
                return false;
            return t.GetCasilla(columna, 5) == TipoCasilla.VACIA;
        }

        public int CuantasSeguidas(Tablero tab, int ox, int oy, int incrx, int incry)
        {
            TipoCasilla expected = tab.GetCasilla(ox, oy);
            int ret = 1;

            while (tab.GetCasilla(ox + incrx, oy + incry) == expected)
            {
                ox += incrx;
                oy += incry;
                ++ret;
            }
            return ret;
        }
    }
}
