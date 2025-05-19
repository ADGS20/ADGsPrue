using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reglas reglas;
            do
            {
                reglas = new Reglas();

                // Inicializamos tablero y turno
                Tablero tablero = reglas.TableroInicial();
                TipoCasilla turno = reglas.QuienEmpieza();
                // Hacemos que el primero en jugar sea el que retorna QuienEmpieza
                turno = reglas.ColorContrario(turno);

                // Bucle de juego
                do
                {
                    turno = reglas.ColorContrario(turno);
                    GUI.PintaTablero(tablero, turno);

                    int col;
                    // Pedimos columna hasta que CaeFicha devuelva true
                    do
                    {
                        col = GUI.PideColumna();
                    } while (!tablero.CaeFicha(col - 1, turno));

                } while (!reglas.Gana(tablero, turno)
                         && !tablero.TableroCompleto());

                // Fin de partida: ganador o tablas
                if (!tablero.TableroCompleto())
                {
                    GUI.EscribeGanador(tablero, turno);
                }
                else
                {
                    GUI.PintaTablero(tablero, TipoCasilla.VACIA);
                    Console.WriteLine(" ==== TABLAS ====");
                }

            } while (GUI.JugarOtra());
        }
    }
}
