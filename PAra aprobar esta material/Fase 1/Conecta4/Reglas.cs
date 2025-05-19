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
    }
}
