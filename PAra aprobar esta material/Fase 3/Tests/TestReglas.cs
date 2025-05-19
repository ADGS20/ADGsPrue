using Conecta4;

using NUnit.Framework;


namespace Tests
{
    [TestFixture]
    public class TestReglas
    {
        [Test]
        public void TestQuienEmpieza()
        {
            // Arrange
            Reglas r = new Reglas();

            // Act
            TipoCasilla empieza = r.QuienEmpieza();

            // Assert
            Assert.That(empieza, Is.EqualTo(TipoCasilla.AMARILLA), "ERROR: Las reglas del juego deben indicar que empizan las amarillas.");
        }

        [Test]
        public void TestNoHaySiguienteAVacia()
        {
            // Arrange
            Reglas r = new Reglas();

            // Act
            TipoCasilla siguiente = r.ColorContrario(TipoCasilla.VACIA);

            // Assert
            Assert.That(siguiente, Is.EqualTo(TipoCasilla.VACIA), "ERROR: el color contrario a VACIA es VACIA");
        }


        [Test]
        public void TestColorContrario()
        {
            // Arrange
            Reglas r = new Reglas();

            // Act
            TipoCasilla inicial = TipoCasilla.ROJA;
            TipoCasilla turno1 = r.ColorContrario(inicial);
            TipoCasilla turno2 = r.ColorContrario(turno1);

            // Assert
            Assert.That(turno1, Is.EqualTo(TipoCasilla.AMARILLA), "ERROR: el color contrario a ROJA es AMARILLA");
            Assert.That(turno2, Is.EqualTo(TipoCasilla.ROJA), "ERROR: el color contrario a AMARILLA es ROJA");
        }

        // Fase 2
        // tests para PuedePoner
        [Test]
        public void PuedePoner_OutOfBounds()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // <-- Usamos Assert.That con Is.False
            Assert.That(reglas.PuedePoner(t, -1), Is.False,
                "ERROR: columna -1 debe devolver false");
            Assert.That(reglas.PuedePoner(t, 7), Is.False,
                "ERROR: columna 7 debe devolver false");
        }

        [Test]
        public void PuedePoner_ColumnaVacia()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // <-- Usamos Assert.That con Is.True
            Assert.That(reglas.PuedePoner(t, 3), Is.True,
                "ERROR: columna 3 vacía debe devolver true");
        }

        [Test]
        public void PuedePoner_ColumnaLlena()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            for (int i = 0; i < 6; i++)
                t.CaeFicha(2, TipoCasilla.AMARILLA);

            Assert.That(reglas.PuedePoner(t, 2), Is.False,
                "ERROR: columna 2 llena debe devolver false");
        }

        //  tests para CuantasSeguidas —

        [Test]
        public void Horizontal_TresSeguidas()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            for (int x = 0; x < 3; x++)
                t.ColocaFicha(x, 0, TipoCasilla.ROJA);

            // Puedes usar Assert.That con Is.EqualTo
            Assert.That(reglas.CuantasSeguidas(t, 0, 0, 1, 0),
                Is.EqualTo(3),
                "ERROR: horizontal debe contar 3");
        }

        [Test]
        public void Vertical_TresSeguidas()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            for (int y = 0; y < 3; y++)
                t.ColocaFicha(4, y, TipoCasilla.AMARILLA);

            Assert.That(reglas.CuantasSeguidas(t, 4, 0, 0, 1),
                Is.EqualTo(3),
                "ERROR: vertical debe contar 3");
        }

        [Test]
        public void Diagonal_TresSeguidas()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            t.ColocaFicha(1, 1, TipoCasilla.ROJA);
            t.ColocaFicha(2, 2, TipoCasilla.ROJA);
            t.ColocaFicha(3, 3, TipoCasilla.ROJA);

            Assert.That(reglas.CuantasSeguidas(t, 1, 1, 1, 1),
                Is.EqualTo(3),
                "ERROR: diagonal debe contar 3");
        }

        [Test]
        public void EmpezandoEnVacia_Cero()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            Assert.That(reglas.CuantasSeguidas(t, 0, 0, 1, 0),
                Is.EqualTo(0),
                "ERROR: empezando en VACIA debe contar 0");
        }

        // Fase 3

        [Test]
        public void Gana_Horizontal()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // Colocamos O O O O en la fila 0, columnas 0..3
            for (int x = 0; x < 4; x++)
                t.CaeFicha(x, TipoCasilla.AMARILLA);
            Assert.That(reglas.Gana(t, TipoCasilla.AMARILLA), Is.True,
                "ERROR: 4 amarillas en horizontal deben ganar");
        }

        [Test]
        public void Gana_Vertical()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // Colocamos 4 rojas en columna 2, filas 0..3
            for (int i = 0; i < 4; i++)
                t.CaeFicha(2, TipoCasilla.ROJA);
            Assert.That(reglas.Gana(t, TipoCasilla.ROJA), Is.True,
                "ERROR: 4 rojas en vertical deben ganar");
        }

        [Test]
        public void Gana_DiagonalAscendente()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // Diagonal ↗: (0,0),(1,1),(2,2),(3,3)
            t.ColocaFicha(0, 0, TipoCasilla.AMARILLA);
            t.ColocaFicha(1, 1, TipoCasilla.AMARILLA);
            t.ColocaFicha(2, 2, TipoCasilla.AMARILLA);
            t.ColocaFicha(3, 3, TipoCasilla.AMARILLA);
            Assert.That(reglas.Gana(t, TipoCasilla.AMARILLA), Is.True,
                "ERROR: 4 amarillas en diagonal ↗ deben ganar");
        }

        [Test]
        public void Gana_DiagonalDescendente()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // Diagonal ↖: (6,0),(5,1),(4,2),(3,3)
            t.ColocaFicha(6, 0, TipoCasilla.ROJA);
            t.ColocaFicha(5, 1, TipoCasilla.ROJA);
            t.ColocaFicha(4, 2, TipoCasilla.ROJA);
            t.ColocaFicha(3, 3, TipoCasilla.ROJA);
            Assert.That(reglas.Gana(t, TipoCasilla.ROJA), Is.True,
                "ERROR: 4 rojas en diagonal ↖ deben ganar");
        }

        [Test]
        public void NoGana_Sin4Seguidas()
        {
            var reglas = new Reglas();
            var t = new Tablero();
            // Tres amarillas no bastan
            for (int x = 0; x < 3; x++)
                t.CaeFicha(x, TipoCasilla.AMARILLA);
            Assert.That(reglas.Gana(t, TipoCasilla.AMARILLA), Is.False,
                "ERROR: 3 amarillas no deben ganar");
        }

    }
}