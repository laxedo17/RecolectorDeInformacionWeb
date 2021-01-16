using RecolectorDeInformacionWeb.Datos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecolectorDeInformacionWeb.Traballadores
{
    public class ParteCriterioRecolectaBuilder
    {
        //public string Regex { get; set; }
        //public RegexOptions OpcionsRegex { get; set; }

        private string _regex;
        private RegexOptions _opcionsRegex;

        /// <summary>
        /// Constructor da clase co que utilizamos o famoso Builder Pattern
        /// </summary>
        public ParteCriterioRecolectaBuilder()
        {
            SituarValoresPorDefecto();
        }

        /// <summary>
        /// Dalle un valor inicial os campos desta clase, que mostren algo. Este metodo e private para que non se modifique fora desta clase.
        /// </summary>
        private void SituarValoresPorDefecto()
        {
            _regex = string.Empty;
            _opcionsRegex = RegexOptions.None;
        }

        public ParteCriterioRecolectaBuilder ConRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ParteCriterioRecolectaBuilder ConOpcionsRegex(RegexOptions opcionsRegex)
        {
            _opcionsRegex = opcionsRegex;
            return this;
        }

        /// <summary>
        /// Construe un obxeto de tipo ParteCriterioRecolecta con valores por defecto
        /// </summary>
        /// <returns></returns>
        public ParteCriterioRecolecta Build()
        {
            ParteCriterioRecolecta parteCriterioRecolecta = new ParteCriterioRecolecta();
            parteCriterioRecolecta.Regex = _regex;
            parteCriterioRecolecta.OpcionsRegex = _opcionsRegex;
            return parteCriterioRecolecta;
        }
    }
}
