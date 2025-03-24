// Andrés Díaz Guerrero Soto
namespace FP2Practica1
{
    class Program
    {
        const int fils = 8, cols = 8;

        struct Posicion
        {
            public int fil, col;
        };

        struct Casilla
        {
            public int num;
            public bool fija;
        };

        struct Tablero
        {
            public Casilla[,] cas;
            public Posicion cursor;
        };

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int[,] mat = {
                { 0, 33, 35,  0,  0, -1, -1, -1 },
                { 0,  0, 24, 22,  0, -1, -1, -1 },
                { 0,  0,  0, 21,  0,  0, -1, -1 },
                { 0, 26,  0, 13, 40, 11, -1, -1 },
                {27,  0,  0,  0,  9,  0,  1, -1 },
                {-1, -1,  0,  0, 18,  0,  0, -1 },
                {-1, -1, -1, -1,  0,  7,  0,  0 },
                {-1, -1, -1, -1, -1, -1,  5,  0 }
            };
            Tablero tab = new Tablero();
            tab.cas = new Casilla[fils, cols];
            Inicializa(mat, ref tab);
            Render(tab);
            while (true)
            {
                char input = LeeInput();
                if (input != ' ')
                {
                    if (input == 'q')
                        break;
                    else if (input == 'c')
                    {
                        Posicion posError;
                        if (Comprueba(tab, out posError))
                        {
                            Render(tab);
                            Console.SetCursorPosition(0, fils * 2 + 2);
                            Console.WriteLine("HAS GANADO!");
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, fils * 2 + 2);
                            Console.WriteLine("PARECE QUE NO ES LA RESPUESTA");
                            RenderCont(tab, posError);
                            Console.ReadKey(true);
                        }
                    }
                    else if (input == 'j')
                    {
                        Inicializa(mat, ref tab);
                    }
                    else
                    {
                        ActualizaEstado(input, ref tab);
                    }
                    Render(tab);
                }
            }
        }

        static void Inicializa(int[,] mat, ref Tablero tab)
        {
            for (int i = 0; i < fils; i++)
                for (int j = 0; j < cols; j++)
                {
                    int valor = mat[i, j];
                    tab.cas[i, j].num = valor;
                    tab.cas[i, j].fija = (valor > 0);
                }
            tab.cursor.fil = 0;
            tab.cursor.col = 0;
        }

        static void Render(Tablero tab)
        {
            Console.Clear();
            for (int i = 0; i < fils; i++)
            {
                int posY = i * 2;
                int offset = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (tab.cas[i, j].num == -1)
                        offset += 4;
                    else
                        break;
                }
                int posX = offset;
                for (int j = 0; j < cols; j++)
                {
                    if (tab.cas[i, j].num != -1)
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        int valor = tab.cas[i, j].num;
                        if (valor > 0)
                        {
                            Console.ForegroundColor = tab.cas[i, j].fija ? ConsoleColor.Black : ConsoleColor.Green;
                            Console.Write(valor.ToString().PadLeft(2));
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                        Console.ResetColor();
                        posX += 4;
                    }
                }
            }
            int cf = tab.cursor.fil;
            int cc = tab.cursor.col;
            int cursorY = cf * 2;
            int cursorOffset = 0;
            for (int j = 0; j < cols; j++)
            {
                if (tab.cas[cf, j].num == -1)
                    cursorOffset += 4;
                else
                    break;
            }
            int cursorX = cursorOffset;
            for (int j = 0; j < cc; j++)
            {
                if (tab.cas[cf, j].num != -1)
                    cursorX += 4;
            }
            Console.SetCursorPosition(cursorX, cursorY);
            Console.BackgroundColor = tab.cas[cf, cc].fija ? ConsoleColor.Gray : ConsoleColor.Yellow;
            int valCursor = tab.cas[cf, cc].num;
            if (valCursor > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(valCursor.ToString().PadLeft(2));
            }
            else
            {
                Console.Write("  ");
            }
            Console.ResetColor();
            int messageY = fils * 2 + 2;
            Console.SetCursorPosition(0, messageY);
            Console.WriteLine("Si pulsa Q para salir, J para reiniciar, C para comprobar,");
            Console.WriteLine("W/A/S/D o flechas para mover, y dígitos 0-9 para introducir números.");
        }

        static void RenderCont(Tablero tab, Posicion pos)
        {
            int posY = pos.fil * 2;
            int posX = 0;
            for (int j = 0; j < cols; j++)
            {
                if (tab.cas[pos.fil, j].num != -1)
                {
                    if (j == pos.col)
                        break;
                    posX += 4;
                }
            }
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Red;
            int valor = tab.cas[pos.fil, pos.col].num;
            if (valor > 0)
            {
                Console.ForegroundColor = tab.cas[pos.fil, pos.col].fija ? ConsoleColor.Black : ConsoleColor.Green;
                Console.Write(valor.ToString().PadLeft(2));
            }
            else
            {
                Console.Write("  ");
            }
            Console.ResetColor();
        }

        static char LeeInput()
        {
            char d = ' ';
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                string tecla = keyInfo.Key.ToString();
                switch (tecla)
                {
                    case "LeftArrow": d = 'l'; break;
                    case "UpArrow": d = 'u'; break;
                    case "RightArrow": d = 'r'; break;
                    case "DownArrow": d = 'd'; break;
                    case "c": case "C": d = 'c'; break;
                    case "Escape": case "q": case "Q": d = 'q'; break;
                    default:
                        if (keyInfo.Key == ConsoleKey.A)
                            d = 'l';
                        else if (keyInfo.Key == ConsoleKey.W)
                            d = 'u';
                        else if (keyInfo.Key == ConsoleKey.D)
                            d = 'r';
                        else if (keyInfo.Key == ConsoleKey.S)
                            d = 'd';
                        else if (keyInfo.Key == ConsoleKey.R)
                            d = 'j';
                        else if (tecla.Length == 2 && tecla[0] == 'D' && tecla[1] >= '0' && tecla[1] <= '9')
                            d = tecla[1];
                        break;
                }
            }
            return d;
        }

        static void ActualizaEstado(char c, ref Tablero tab)
        {
            int nf = tab.cursor.fil;
            int nc = tab.cursor.col;
            if (c == 'l' || c == 'r' || c == 'u' || c == 'd')
            {
                if (c == 'r')
                {
                    int next = -1;
                    for (int j = nc + 1; j < cols; j++)
                    {
                        if (tab.cas[nf, j].num != -1)
                        {
                            next = j;
                            break;
                        }
                    }
                    if (next != -1)
                        nc = next;
                    else if (nf < fils - 1)
                    {
                        nf++;
                        for (int j = 0; j < cols; j++)
                        {
                            if (tab.cas[nf, j].num != -1)
                            {
                                nc = j;
                                break;
                            }
                        }
                    }
                }
                else if (c == 'l')
                {
                    int prev = -1;
                    for (int j = nc - 1; j >= 0; j--)
                    {
                        if (tab.cas[nf, j].num != -1)
                        {
                            prev = j;
                            break;
                        }
                    }
                    if (prev != -1)
                        nc = prev;
                    else if (nf > 0)
                    {
                        nf--;
                        for (int j = cols - 1; j >= 0; j--)
                        {
                            if (tab.cas[nf, j].num != -1)
                            {
                                nc = j;
                                break;
                            }
                        }
                    }
                }
                else if (c == 'd')
                {
                    bool found = false;
                    for (int i = nf + 1; i < fils; i++)
                    {
                        if (tab.cas[i, nc].num != -1)
                        {
                            nf = i;
                            found = true;
                            break;
                        }
                    }
                    if (!found && nc < cols - 1)
                    {
                        nc++;
                        for (int i = 0; i < fils; i++)
                        {
                            if (tab.cas[i, nc].num != -1)
                            {
                                nf = i;
                                break;
                            }
                        }
                    }
                }
                else if (c == 'u')
                {
                    bool found = false;
                    for (int i = nf - 1; i >= 0; i--)
                    {
                        if (tab.cas[i, nc].num != -1)
                        {
                            nf = i;
                            found = true;
                            break;
                        }
                    }
                    if (!found && nc > 0)
                    {
                        nc--;
                        for (int i = fils - 1; i >= 0; i--)
                        {
                            if (tab.cas[i, nc].num != -1)
                            {
                                nf = i;
                                break;
                            }
                        }
                    }
                }
                tab.cursor.fil = nf;
                tab.cursor.col = nc;
            }
            else if (char.IsDigit(c))
            {
                int digito = c - '0';
                int f = tab.cursor.fil;
                int co = tab.cursor.col;
                if (!tab.cas[f, co].fija)
                {
                    int actual = tab.cas[f, co].num;
                    if (actual == 0)
                    {
                        if (digito != 0)
                            tab.cas[f, co].num = digito;
                    }
                    else if (actual > 0 && actual < 10)
                    {
                        tab.cas[f, co].num = actual * 10 + digito;
                    }
                    else
                    {
                        tab.cas[f, co].num = (digito == 0 ? 0 : digito);
                    }
                }
            }
        }

        static Posicion Busca1(Tablero tab)
        {
            Posicion pos = tab.cursor;
            for (int i = 0; i < fils; i++)
                for (int j = 0; j < cols; j++)
                    if (tab.cas[i, j].num == 1 && tab.cas[i, j].fija)
                    {
                        pos.fil = i;
                        pos.col = j;
                        return pos;
                    }
            return pos;
        }

        static int Ultimo(Tablero tab)
        {
            int max = 0;
            for (int i = 0; i < fils; i++)
                for (int j = 0; j < cols; j++)
                    if (tab.cas[i, j].num > max)
                        max = tab.cas[i, j].num;
            return max;
        }

        static bool Siguiente(Tablero tab, Posicion pos, out Posicion pos1)
        {
            pos1 = new Posicion();
            int n = tab.cas[pos.fil, pos.col].num;
            int objetivo = n + 1;
            int[] df = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int k = 0; k < 8; k++)
            {
                int nf = pos.fil + df[k];
                int nc = pos.col + dc[k];
                if (nf >= 0 && nf < fils && nc >= 0 && nc < cols)
                {
                    if (tab.cas[nf, nc].num == objetivo)
                    {
                        pos1.fil = nf;
                        pos1.col = nc;
                        return true;
                    }
                }
            }
            return false;
        }

        static bool Comprueba(Tablero tab, out Posicion posError)
        {
            posError = new Posicion();
            Posicion p1 = Busca1(tab);
            if (tab.cas[p1.fil, p1.col].num != 1)
            {
                posError = p1;
                return false;
            }
            int ult = Ultimo(tab);
            Posicion actual = p1;
            for (int n = 1; n < ult; n++)
            {
                Posicion siguiente;
                if (!Siguiente(tab, actual, out siguiente))
                {
                    posError = actual;
                    return false;
                }
                actual = siguiente;
            }
            return true;
        }
    }
}