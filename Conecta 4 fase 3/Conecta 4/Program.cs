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
                Tablero tablero = new Tablero(); // También podrías implementar reglas.TableroInicial()
                TipoCasilla turno = reglas.QuienEmpieza();
                // Se considera que el "último en poner" es el color contrario a quien empieza.
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
