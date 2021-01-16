using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecolectorDeInformacionWeb.Datos
{
    public class ParteCriterioRecolecta
    {
        public string Regex { get; set; }
        public RegexOptions OpcionsRegex { get; set; }
    }
}
