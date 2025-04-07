using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta_4
{
    public class GUI
    {
        public static void PintaTablero(Tablero t, TipoCasilla turno)
        {
            for (int y = 5; y >= 0; y--)
            {
                string line = "|";
                for (int x = 0; x < 7; x++)
                {
                    line += ToChar(t.GetCasilla(x, y));
                }
                line += "|";
                Console.WriteLine(line);
            }
            Console.WriteLine(new string('=', 9));
            Console.WriteLine();
            if (turno != TipoCasilla.VACIA)
            {
                Console.WriteLine("Juegan " + ToUserFriendly(turno) + " (" + ToChar(turno) + ")");
                Console.WriteLine();
            }
        }

        public static int PideColumna()
        {
            Console.Write("Indica la columna donde colocar la ficha: ");
            int col;
            while (!int.TryParse(Console.ReadLine(), out col))
            {
                Console.Write("Entrada inválida. Indica la columna: ");
            }
            return col;
        }

        public static void EscribeGanador(Tablero t, TipoCasilla ganador)
        {
            Console.WriteLine();
            PintaTablero(t, TipoCasilla.VACIA);
            Console.WriteLine("FIN DE JUEGO. Ganan " + ToUserFriendly(ganador));
        }

        public static bool JugarOtra()
        {
            Console.Write("Otra partida? (S/N): ");
            string respuesta = Console.ReadLine().ToLower();
            return respuesta == "s";
        }

        private static char ToChar(TipoCasilla t)
        {
            switch (t)
            {
                case TipoCasilla.ROJA:
                    return 'X';
                case TipoCasilla.AMARILLA:
                    return 'O';
                default:
                    return ' ';
            }
        }

        private static string ToUserFriendly(TipoCasilla t)
        {
            switch (t)
            {
                case TipoCasilla.ROJA:
                    return "rojas";
                case TipoCasilla.AMARILLA:
                    return "amarillas";
                default:
                    return "";
            }
        }
    }
}
