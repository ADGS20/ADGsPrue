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

        public bool Gana (Tablero tablero, TipoCasilla color)
        {
            int columnas = 7;
            int filas = 6;

            //Direcciones a comprobar: (dc, dy)

            int[,] direcciones = new int[,] 
            { 
                { 1, 0 }, 
                { 0, 1 }, 
                { 1, 1 }, 
                { 1, -1 }
            };

            for (int x = 0; x < columnas; x++)
            {
                for (int y = 0; y < filas; y++)
                {
                    if (tablero.GetCasilla(x,y) == color)
                    {
                        for (int d = 0; d < direcciones.GetLength(0); d++)
                        {
                            int dx = direcciones [d, 0];
                            int dy = direcciones [d, 1];
                            int count = 1;

                            int nx = x + dx;
                            int ny = y + dy;
                            while (tablero.GetCasilla(nx, ny) == color)
                            {
                                count++;
                                nx += dx;
                                ny += dy;
                            }

                            nx = x - dx;
                            ny = y - dy;
                            while (tablero.GetCasilla(nx, ny) == color)
                            {
                                count++;
                                nx -= dx;
                                ny -= dy;
                            }

                            if (count >= 4)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
