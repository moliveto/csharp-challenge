using DevelopmentChallenge.Data.Resources;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea() => (decimal)Math.Sqrt(3) / 4 * _lado * _lado;
        public override decimal CalcularPerimetro() => _lado * 3;

        public override string GetNombre(bool plural = false, string cultureName = "en-US")
        {
            if (!string.IsNullOrWhiteSpace(cultureName)) { _culture = new CultureInfo(cultureName); }
            return plural ? rm.GetString("Triangulo_NombrePlural", _culture) : rm.GetString("Triangulo_NombreSingular", _culture);
        }
    }
}
