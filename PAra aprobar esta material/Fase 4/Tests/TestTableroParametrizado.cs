using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Conecta4;

namespace Tests
{
    [TestFixture]
    public class TestTableroParametrizado
    {
        // Test del constructor por defecto: debe inicializar un tablero 6x7
        [Test]
        public void ConstructorPorDefecto_Tamanio6x7()
        {
            var t = new Tablero();
            Assert.That(t.Filas, Is.EqualTo(6));
            Assert.That(t.Columnas, Is.EqualTo(7));
        }

        // Test del constructor parametrizado: tablero de tamaño variable
        [Test]
        public void ConstructorParametrizado_TamanioVariable()
        {
            var t = new Tablero(3, 5);
            Assert.That(t.Filas, Is.EqualTo(3));
            Assert.That(t.Columnas, Is.EqualTo(5));
            // Un tablero recién creado no debe estar completo
            Assert.That(t.TableroCompleto(), Is.False);
        }

        // Test de TableroCompleto en tablero dinámico: 2x2 completamente lleno
        [Test]
        public void TableroCompleto_Dinamico_Ok()
        {
            var t = new Tablero(2, 2);
            // Colocamos fichas en todas las posiciones del tablero 2x2
            for (int x = 0; x < 2; x++)
                for (int y = 0; y < 2; y++)
                    t.ColocaFicha(x, y, TipoCasilla.ROJA);
            // Ahora el tablero debe estar completo según el contador interno
            Assert.That(t.TableroCompleto(), Is.True);
        }
    }
}

