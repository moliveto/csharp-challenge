using DevelopmentChallenge.Data.Resources;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea() => _lado * _lado;
        public override decimal CalcularPerimetro() => _lado * 4;
        public override string GetNombre(bool plural = false, string cultureName = "en-US")
        {
            if (!string.IsNullOrWhiteSpace(cultureName)) { _culture = new CultureInfo(cultureName); }
            return plural ? rm.GetString("Cuadrado_NombrePlural", _culture) : rm.GetString("Cuadrado_NombreSingular", _culture);
        }
    }
}
