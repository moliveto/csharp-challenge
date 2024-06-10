using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Extensions
{
    public static class IdiomasExtension
    {
        public static CultureInfo ToCulture(this IdiomasEnum idiomasEnum)
        {
            switch (idiomasEnum)
            {
                case IdiomasEnum.Castellano:
                    return new CultureInfo("es-ES");
                case IdiomasEnum.Ingles:
                    return new CultureInfo("en-US");
                case IdiomasEnum.Italiano:
                    return new CultureInfo("it-IT");
                default:
                    return new CultureInfo("en-US");
            }
        }
    }
}
