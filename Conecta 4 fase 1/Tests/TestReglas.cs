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

    }
}
