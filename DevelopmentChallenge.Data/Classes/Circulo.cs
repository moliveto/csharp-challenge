using DevelopmentChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{

    public class Circulo : FormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio) 
        {
            _radio = radio;
        }

        public override decimal CalcularArea() => (decimal)Math.PI * (_radio / 2) * (_radio / 2);
        public override decimal CalcularPerimetro() => (decimal)Math.PI * _radio;


        public override string GetNombre(bool plural = false, string cultureName = "en-US")
        {
            if (!string.IsNullOrWhiteSpace(cultureName)) { _culture = new CultureInfo(cultureName); }
            return plural ? rm.GetString("Circulo_NombrePlural", _culture) : rm.GetString("Circulo_NombreSingular", _culture);
        }
    }
}
