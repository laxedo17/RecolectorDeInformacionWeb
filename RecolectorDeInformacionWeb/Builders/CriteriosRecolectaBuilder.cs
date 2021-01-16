using RecolectorDeInformacionWeb.Datos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecolectorDeInformacionWeb.Traballadores
{
    /// <summary>
    /// Clase na que usaremos o famoso Builder Pattern (un patron para crear multiples obxetos dunha clase con valores diseñados e predefinidos para facer a instanciacion moitisimo mais axil
    /// </summary>
    public class CriteriosRecolectaBuilder
    {

        //public string Datos { get; set; }
        //public string Regex { get; set; }
        //public RegexOptions OpcionsRegex { get; set; }
        //public List<ParteCriterioRecolecta> Partes { get; set; }

        //Basados nos atributos orixinales da clase CriteriosRecolecta, pasamolos a campos (fields) en vez de ser atributos. Sendo fields e private, por norma nomeanse con guion baixo.
        private string _datos;
        private string _regex;
        private RegexOptions _opcionsRegex;
        private List<ParteCriterioRecolecta> _partes;

        public CriteriosRecolectaBuilder()
        {
            SituarValoresPorDefecto();
        }

        private void SituarValoresPorDefecto()
        {
            _datos = string.Empty;
            _regex = string.Empty;
            _opcionsRegex = RegexOptions.None;
            _partes = new List<ParteCriterioRecolecta>();
        }

        public CriteriosRecolectaBuilder ConDatos(string datos)
        {
            _datos = datos;
            return this;//return this, significa que devolvemos o obxeto afectado COMPLETO, asi se cambiamos este dato, o resto sigue igual no obxeto pero o dato afectado si cambia, moi potente o Builder Pattern
        }

        public CriteriosRecolectaBuilder ConRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public CriteriosRecolectaBuilder ConOpcionsRegex(RegexOptions opcionsRegex)
        {
            _opcionsRegex = opcionsRegex;
            return this;
        }

        public CriteriosRecolectaBuilder ConParte(ParteCriterioRecolecta parteCriterioRecoleta)
        {
            _partes.Add(parteCriterioRecoleta); //isto e importante. Tratandose dunha lista, o que queremos e engadir esta parte a lista, non facemos como nos outros casos k son campos individuales
            return this;
        }

        /// <summary>
        /// Metodo que construe usango Builder Patter un obxeto da clase CriteriosRecolecta, o cal permite ter un obxeto da clase construido o momento sen ter que usar o tipico patron de por exemplo, Obxeto oObxetoQueSexa = new Obxeto("propiedade string", int, "outro string", double, float, 'char') etc etc. Se o obxeto require moitos datos volvería tolo a calquera.
        /// Pasamoslle como valor as propiedades e atributos da clase os campos ou fields que creamos.
        /// </summary>
        /// <returns></returns>
        public CriteriosRecolecta Build()
        {
            CriteriosRecolecta criteriosRecolecta = new CriteriosRecolecta();
            criteriosRecolecta.Datos = _datos;
            criteriosRecolecta.Regex = _regex;
            criteriosRecolecta.OpcionsRegex = _opcionsRegex;
            criteriosRecolecta.Partes = _partes;
            return criteriosRecolecta;
        }
     }
}
