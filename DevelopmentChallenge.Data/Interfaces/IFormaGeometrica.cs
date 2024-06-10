using System.Globalization;

namespace DevelopmentChallenge.Data.Classes
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string NombreSingular(string cultureName = "en-US");
        string NombrePlural(string cultureName = "en-US");
        string GetNombre(bool plural = false, string cultureName = "en-US");
    }
}
