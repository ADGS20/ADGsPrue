using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    class Program
    {
        static void Main(string[] args)
        {
            Reglas reglas;
            do
            {
                Console.Write("Número de filas: ");
                int filas = int.Parse(Console.ReadLine());
                Console.Write("Número de columnas: ");
                int columnas = int.Parse(Console.ReadLine());

                reglas = new Reglas();
                Tablero tablero = new Tablero(filas, columnas);
                TipoCasilla turno = reglas.QuienEmpieza();
                turno = reglas.ColorContrario(turno);

                do
                {
                    turno = reglas.ColorContrario(turno);
                    GUI.PintaTablero(tablero, turno);

                    int col;
                    do
                    {
                        col = GUI.PideColumna(1, tablero.Columnas);
                    } while (!tablero.CaeFicha(col - 1, turno));

                } while (!reglas.Gana(tablero, turno)
                         && !tablero.TableroCompleto());

                if (!tablero.TableroCompleto())
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