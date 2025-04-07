using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta_4
{
    public class Tablero
    {
        public int Columnas { get; private set; }
        public int Filas { get; private set; }
        private TipoCasilla[,] casillas;
        private int fichasColocadas; // Contador de fichas colocadas

        public Tablero() : this(7, 6)
        {

        }

        // Constructor con tamaño variable
        public Tablero(int columnas, int filas)
        {
            Columnas = columnas;
            Filas = filas;
            casillas = new TipoCasilla[Columnas, Filas];
            fichasColocadas = 0;
        }

        public void ColocaFicha(int x, int y, TipoCasilla color)
        {
            if (color == TipoCasilla.VACIA)
                return;
            if (x < 0 || x >= Columnas || y < 0 || y >= Filas)
                return;
            if (casillas[x, y] != TipoCasilla.VACIA)
                return;
            casillas[x, y] = color;
            fichasColocadas++;
        }

        public bool CaeFicha(int x, TipoCasilla color)
        {
            if (x < 0 || x >= Columnas)
                return false;
            if (color == TipoCasilla.VACIA)
                return false;
            for (int y = 0; y < Filas; y++)
            {
                if (casillas[x, y] == TipoCasilla.VACIA)
                {
                    casillas[x, y] = color;
                    fichasColocadas++;
                    return true;
                }
            }
            return false;
        }

        // Ahora se comprueba simplemente si el contador de fichas es igual al total de celdas
        public bool TableroCompleto()
        {
            return fichasColocadas >= Columnas * Filas;
        }

        public TipoCasilla GetCasilla(int x, int y)
        {
            if (x < 0 || x >= Columnas || y < 0 || y >= Filas)
                return TipoCasilla.VACIA;
            return casillas[x, y];
        }
    }
}
