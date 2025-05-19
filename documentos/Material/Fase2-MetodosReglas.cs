        /// <summary>
        /// ¿Se puede poner en la columna indicada?
        /// </summary>
        /// <param name="t"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public bool PuedePoner(Tablero t, int columna)
        {
            return t.GetCasilla(columna, 5) == TipoCasilla.VACIA;
        }

        public int CuantasSeguidas(Tablero tab, int ox, int oy, int incrx, int incry)
        {
            TipoCasilla expected = tab.GetCasilla(ox, oy);
            int ret = 1;

            while (tab.GetCasilla(ox + incrx, oy + incry) == expected) {
                ox += incrx;
                oy += incry;
                ++ret;
            }
            return ret;
        }
