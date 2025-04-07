using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Reglas reglas;
            do
            {
                reglas = new Reglas();

                // Preguntar al usuario el tamaño del tablero
                Console.Write("Indica el número de columnas para el tablero (mínimo 4): ");
                int columnas;
                while (!int.TryParse(Console.ReadLine(), out columnas) || columnas < 4)
                {
                    Console.Write("Entrada inválida. Indica un número de columnas (mínimo 4): ");
                }

                Console.Write("Indica el número de filas para el tablero (mínimo 4): ");
                int filas;
                while (!int.TryParse(Console.ReadLine(), out filas) || filas < 4)
                {
                    Console.Write("Entrada inválida. Indica un número de filas (mínimo 4): ");
                }

                Tablero tablero = new Tablero(columnas, filas);
                TipoCasilla turno = reglas.QuienEmpieza();
                turno = reglas.ColorContrario(turno);

                do
                {
                    turno = reglas.ColorContrario(turno);
                    GUI.PintaTablero(tablero, turno);
                    int col;
                    do
                    {
                        col = GUI.PideColumna();
                    } while (!tablero.CaeFicha(col - 1, turno));

                } while (!reglas.Gana(tablero, turno) && !tablero.TableroCompleto());

                if (reglas.Gana(tablero, turno))
                    GUI.EscribeGanador(tablero, turno);
                else
                {
                    GUI.PintaTablero(tablero, TipoCasilla.VACIA);
                    Console.WriteLine(" ==== TABLAS ====");
                }
            } while (GUI.JugarOtra());
        }
    }
}
