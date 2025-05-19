using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    /// <summary>
    /// Representa el estado de cada celda:
    /// VACIA = sin ficha, AMARILLA/ROJA = ficha de cada jugador.
    /// </summary>
    public enum TipoCasilla
    {
        VACIA,
        AMARILLA,
        ROJA
    }
}
