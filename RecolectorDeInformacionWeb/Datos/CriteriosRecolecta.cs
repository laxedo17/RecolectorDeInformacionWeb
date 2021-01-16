using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecolectorDeInformacionWeb.Datos
{
    public class CriteriosRecolecta
    {
        public CriteriosRecolecta()
        {
            Partes = new List<ParteCriterioRecolecta>();
        }

        public string Datos { get; set; }
        public string Regex { get; set; }
        public RegexOptions OpcionsRegex { get; set; }
        public List<ParteCriterioRecolecta> Partes { get; set; }
    }
}
