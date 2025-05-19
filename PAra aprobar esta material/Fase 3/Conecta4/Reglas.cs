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

        // Fase 3

        /// <summary>
        /// Devuelve un tablero inicial vacío.
        /// </summary>
        public Tablero TableroInicial()
        {
            // Por ahora, un Tablero recién creado
            return new Tablero();
        }

        /// <summary>
        /// Comprueba si el jugador 'turno' ha conseguido 4 fichas
        /// seguidas en horizontal, vertical o diagonal.
        /// </summary>
        public bool Gana(Tablero tablero, TipoCasilla turno)
        {
            // Recorremos cada casilla
            for (int y = 0; y < 6; y++)
                for (int x = 0; x < 7; x++)
                {
                    // Sólo empezamos conteo desde casillas de 'turno'
                    if (tablero.GetCasilla(x, y) != turno)
                        continue;

                    // 4 en horizontal →
                    if (CuantasSeguidas(tablero, x, y, 1, 0) >= 4) return true;
                    // 4 en vertical ↑
                    if (CuantasSeguidas(tablero, x, y, 0, 1) >= 4) return true;
                    // 4 en diag ↗
                    if (CuantasSeguidas(tablero, x, y, 1, 1) >= 4) return true;
                    // 4 en diag ↖
                    if (CuantasSeguidas(tablero, x, y, -1, 1) >= 4) return true;
                }
            return false;
        }
    }
}
