using DevelopmentChallenge.Data.Resources;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura) :base()
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal CalcularArea() => (_altura / 2) * (_baseMayor + _baseMenor);
        public override decimal CalcularPerimetro()
        {
            decimal lado = (decimal)Math.Sqrt((double)((_baseMayor - _baseMenor) / 2 * (_baseMayor - _baseMenor) / 2 + _altura * _altura));
            return _baseMayor + _baseMenor + 2 * lado;
        }

        public override string GetNombre(bool plural = false, string cultureName = "en-US")
        {
            if (!string.IsNullOrWhiteSpace(cultureName)) { _culture = new CultureInfo(cultureName); }
            return plural ? rm.GetString("Trapecio_NombrePlural", _culture) : rm.GetString("Trapecio_NombreSingular", _culture);
        }
    }
}