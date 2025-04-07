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
    }
}
