using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            ClassicAssert.AreEqual("<h1>Lista vacía de formas!</h1>",
                new FormaGeometrica().Imprimir(new List<IFormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            ClassicAssert.AreEqual("<h1>Empty list of shapes!</h1>",
                new FormaGeometrica().Imprimir(new List<IFormaGeometrica>(), Enums.IdiomasEnum.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = new FormaGeometrica().Imprimir(cuadrados, Enums.IdiomasEnum.Castellano);

            ClassicAssert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25.00 | Perimetro 20.00 <br/>TOTAL:<br/>1 formas Perimetro 20.00 Area 25.00", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = new FormaGeometrica().Imprimir(cuadrados, Enums.IdiomasEnum.Ingles);

            ClassicAssert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35.00 | Perimeter 36.00 <br/>TOTAL:<br/>3 shapes Perimeter 36.00 Area 35.00", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = new FormaGeometrica().Imprimir(formas, Enums.IdiomasEnum.Ingles);

            ClassicAssert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29.00 | Perimeter 28.00 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.60 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = new FormaGeometrica().Imprimir(formas, Enums.IdiomasEnum.Castellano);

            ClassicAssert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29.00 | Perimetro 28.00 <br/>2 Círculos | Area 13.01 | Perimetro 18.06 <br/>3 Triángulos | Area 49.64 | Perimetro 51.60 <br/>TOTAL:<br/>7 formas Perimetro 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = new FormaGeometrica().Imprimir(formas, Enums.IdiomasEnum.Italiano);

            ClassicAssert.AreEqual(
                "<h1>Report delle forme</h1>2 Quadrati | Area 29.00 | Perimetro 28.00 <br/>2 Cerchi | Area 13.01 | Perimetro 18.06 <br/>3 Triangoli | Area 49.64 | Perimetro 51.60 <br/>TOTAL:<br/>7 forme Perimetro 97.66 Area 91.65",
                resumen);
        }


        [TestCase]
        public void TestTrapecio_Default()
        {
            var trapecio = new Trapecio(5, 3, 2);
            ClassicAssert.AreEqual(8, trapecio.CalcularArea());
            ClassicAssert.AreEqual(12.47213595499958m, trapecio.CalcularPerimetro());
            ClassicAssert.AreEqual("trapeze", trapecio.GetNombre(false, "en-US"));
            ClassicAssert.AreEqual("trapezoids", trapecio.GetNombre(true, "en-US"));
        }


        [TestCase]
        public void TestTrapecio_Es_AR()
        {
            const string cultureName = "es-AR";
            var trapecio = new Trapecio(5, 3, 2);
            ClassicAssert.AreEqual(8, trapecio.CalcularArea());
            ClassicAssert.AreEqual(12.47213595499958m, trapecio.CalcularPerimetro());
            ClassicAssert.AreEqual("Trapecio", trapecio.GetNombre(false, cultureName));
            ClassicAssert.AreEqual("Trapecios", trapecio.GetNombre(true, cultureName));
        }

        [TestCase]
        public void TestTrapecio_En_US()
        {
            const string cultureName = "en-US";
            var trapecio = new Trapecio(5, 3, 2);
            ClassicAssert.AreEqual(8, trapecio.CalcularArea());
            ClassicAssert.AreEqual(12.47213595499958m, trapecio.CalcularPerimetro());
            ClassicAssert.AreEqual("trapeze", trapecio.GetNombre(false, cultureName));
            ClassicAssert.AreEqual("trapezoids", trapecio.GetNombre(true, cultureName));
        }

    }
}
