using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta_4
{
    public class Tablero
    {
        private const int COLUMNAS = 7;
        private const int FILAS = 6;
        private TipoCasilla[,] casillas;

        public Tablero()
        {
            casillas = new TipoCasilla[COLUMNAS, FILAS];
        }
        public void ColocaFicha(int x,int y,TipoCasilla color)
        {
            if (color == TipoCasilla.VACIA)
                return;
            if (x < 0 || x >= COLUMNAS || y < 0 || y >= FILAS)
                return;
            if (casillas[x, y] != TipoCasilla.VACIA)
                return;
            casillas[x,y] = color;
        }
        public bool CaeFicha(int x , TipoCasilla color)
        {
            if (x < 0 || x >= COLUMNAS)
                return false;
            for (int y = 0; y< FILAS; y++)
            {
                if (casillas[x,y] == TipoCasilla.VACIA)
                {
                    casillas[x, y] = color;
                    return true;
                }    
            }
            return false;
        }
        public bool TableroCompleto()
        {
            for (int i = 0;i < COLUMNAS;i++)
            {
                for (int j = 0;j < FILAS;j++)
                {
                    if (casillas[i, j] == TipoCasilla.VACIA)
                        return false;
                }
            }
            return true;
        }
        public TipoCasilla GetCasilla(int x, int y)
        {
            if (x < 0 || x >= COLUMNAS || y < 0 || y >= FILAS)
                return TipoCasilla.VACIA;
            return casillas[x, y];
        }
    }
}
