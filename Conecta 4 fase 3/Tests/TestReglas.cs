using Conecta_4;

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
        [Test]
        public void TestOutOfBounds ()
        {
            //Arange
            Reglas r = new Reglas();
            Tablero tab = new Tablero();

            //Act
            bool puedeponer = r.PuedePoner(tab, -1);

            //Assert 
            Assert.That(puedeponer,Is.False, "ERROR: No se puede poner en una casilla inexistente");
        }
        [Test]
        public void TestColumnaLLena()
        {
            //Arange
            Reglas r = new Reglas();
            Tablero tab = new Tablero();

            //Act
            tab.ColocaFicha(3, 5,TipoCasilla.ROJA);
            bool puedeponer = r.PuedePoner(tab, 3);

            //Assert 
            Assert.That(puedeponer, Is.False, "ERROR: No se puede poner en una columna llena");
        }
        [Test]
        public void TestColumnaConEspacio()
        {
            //Arange
            Reglas r = new Reglas();
            Tablero tab = new Tablero();

            //Act
            tab.ColocaFicha(3, 3, TipoCasilla.ROJA);
            bool puedeponer = r.PuedePoner(tab, 3);

            //Assert 
            Assert.That(puedeponer, Is.True, "ERROR: Si se puede poner en una columna con espacio");
        }
    }
}
