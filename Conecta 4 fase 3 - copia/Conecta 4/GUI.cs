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
            for (int y = t.Filas - 1; y >= 0; y--)
            {
                Console.Write("|");
                for (int x = 0; x < t.Columnas; x++)
                {
                    TipoCasilla casilla = t.GetCasilla(x, y);
                    switch (casilla)
                    {
                        case TipoCasilla.ROJA:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            break;
                        case TipoCasilla.AMARILLA:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("O");
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }

            // Dibujar el borde inferior
            int total = t.Columnas + 2;
            Console.WriteLine(new string('=', total));
            Console.WriteLine();

            if (turno != TipoCasilla.VACIA)
            {
                Console.Write("Juegan ");
                switch (turno)
                {
                    case TipoCasilla.ROJA:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("rojas");
                        break;
                    case TipoCasilla.AMARILLA:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("amarillas");
                        break;
                    default:
                        Console.Write("");
                        break;
                }
                Console.ResetColor();
                Console.WriteLine();
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
