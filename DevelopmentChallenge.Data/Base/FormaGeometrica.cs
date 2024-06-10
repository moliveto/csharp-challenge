using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Resources;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using DevelopmentChallenge.Data.Extensions;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometricaBase : IFormaGeometrica
    {
        protected CultureInfo _culture = new CultureInfo("en-US");
        protected ResourceManager rm = new ResourceManager("DevelopmentChallenge.Data.Resources.Shapes", typeof(Shapes).Assembly);

        protected FormaGeometricaBase(string cultureName = "en-US")
        {
            _culture = new CultureInfo(cultureName);
        }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public string NombreSingular(string cultureName = "en-US") => GetNombre(false, cultureName);
        public string NombrePlural(string cultureName = "en-US") => GetNombre(true, cultureName);

        public string Imprimir(List<IFormaGeometrica> formas, IdiomasEnum idiomasEnum = IdiomasEnum.Castellano)
        {
            var printCulture = new CultureInfo("en-US");

            _culture = idiomasEnum.ToCulture();

            var sb = new StringBuilder();
            if (!formas.Any())
            {
                sb.Append($"<h1>{rm.GetString("Empty_List", _culture)}</h1>");
                return sb.ToString();
            }

            /* Header */
            sb.Append($"<h1>{rm.GetString("Header", _culture)}</h1>");

            var groupedFormas = formas.GroupBy(f => f.GetType());

            foreach (var group in groupedFormas)
            {
                var areaTotal = group.Sum(f => f.CalcularArea());
                var perimetroTotal = group.Sum(f => f.CalcularPerimetro());
                var nombreForma = group.Count() > 1 ? group.First().NombrePlural(_culture.Name) : group.First().NombreSingular(_culture.Name);

                sb.Append($"{group.Count()} {nombreForma} | Area {areaTotal.ToString("N2", printCulture)} | {rm.GetString("Perimetro", _culture)} {perimetroTotal.ToString("N2", printCulture)} <br/>");
            }

            var totalArea = formas.Sum(f => f.CalcularArea());
            var totalPerimeter = formas.Sum(f => f.CalcularPerimetro());

            sb.Append($"TOTAL:<br/>{formas.Count} ");

            string formKey = "Formas_NombresPlural"; // Always plural, alternative is string formKey = (formas.Count > 1) ? "Formas_NombresPlural" : "Formas_NombresSingular";
            sb.Append($"{rm.GetString(formKey, _culture)} ");
            sb.Append($"{rm.GetString("Perimetro", _culture)} {totalPerimeter.ToString("N2", printCulture)} Area {totalArea.ToString("N2", printCulture)}");

            return sb.ToString();
        }

        public abstract string GetNombre(bool plural = false, string cultureName = "en-US");
    }

    public class FormaGeometrica : FormaGeometricaBase
    {
        public FormaGeometrica(string cultureName = "en-US") : base(cultureName) { }

        public override decimal CalcularArea() => 0;
        public override decimal CalcularPerimetro() => 0;
        public override string GetNombre(bool plural = false, string cultureName = "en-US") => rm.GetString("FormaGeometrica_Nombre", _culture);
    }
}
