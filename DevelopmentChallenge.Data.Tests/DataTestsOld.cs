﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTestsOld
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            ClassicAssert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometricaOld.Imprimir(new List<FormaGeometricaOld>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            ClassicAssert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometricaOld.Imprimir(new List<FormaGeometricaOld>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometricaOld> { new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 5) };

            var resumen = FormaGeometricaOld.Imprimir(cuadrados, FormaGeometricaOld.Castellano);

            ClassicAssert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometricaOld>
            {
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 5),
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 1),
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 3)
            };

            var resumen = FormaGeometricaOld.Imprimir(cuadrados, FormaGeometricaOld.Ingles);

            ClassicAssert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometricaOld>
            {
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 5),
                new FormaGeometricaOld(FormaGeometricaOld.Circulo, 3),
                new FormaGeometricaOld(FormaGeometricaOld.TrianguloEquilatero, 4),
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 2),
                new FormaGeometricaOld(FormaGeometricaOld.TrianguloEquilatero, 9),
                new FormaGeometricaOld(FormaGeometricaOld.Circulo, 2.75m),
                new FormaGeometricaOld(FormaGeometricaOld.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometricaOld.Imprimir(formas, FormaGeometricaOld.Ingles);

            ClassicAssert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometricaOld>
            {
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 5),
                new FormaGeometricaOld(FormaGeometricaOld.Circulo, 3),
                new FormaGeometricaOld(FormaGeometricaOld.TrianguloEquilatero, 4),
                new FormaGeometricaOld(FormaGeometricaOld.Cuadrado, 2),
                new FormaGeometricaOld(FormaGeometricaOld.TrianguloEquilatero, 9),
                new FormaGeometricaOld(FormaGeometricaOld.Circulo, 2.75m),
                new FormaGeometricaOld(FormaGeometricaOld.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometricaOld.Imprimir(formas, FormaGeometricaOld.Castellano);

            ClassicAssert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

    }
}
