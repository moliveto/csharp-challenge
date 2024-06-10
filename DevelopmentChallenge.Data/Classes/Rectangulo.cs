using DevelopmentChallenge.Data.Resources;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        private readonly decimal _largo;
        private readonly decimal _ancho;

        public Rectangulo(decimal largo, decimal ancho) 
        {
            _largo = largo;
            _ancho = ancho;
        }

        public override decimal CalcularArea() => _largo * _ancho;
        public override decimal CalcularPerimetro() => 2 * (_largo + _ancho);

        public override string GetNombre(bool plural = false, string cultureName = "en-US")
        {
            if (!string.IsNullOrWhiteSpace(cultureName)) { _culture = new CultureInfo(cultureName); }
            return plural ? rm.GetString("Rectangulo_NombrePlural", _culture) : rm.GetString("Rectangulo_NombreSingular", _culture);
        }
    }
}
