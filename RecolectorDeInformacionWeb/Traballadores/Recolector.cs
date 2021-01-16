using RecolectorDeInformacionWeb.Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RecolectorDeInformacionWeb.Traballadores
{
    public class Recolector
    {
        public List<string> Recolecta(CriteriosRecolecta criteriosRecolecta)
        {
            List<string> elementosRecolectados = new List<string>();

            MatchCollection coincidencias = Regex.Matches(criteriosRecolecta.Datos, criteriosRecolecta.Regex, criteriosRecolecta.OpcionsRegex);

            foreach (Match coincidencia in coincidencias)
            {
                if (!criteriosRecolecta.Partes.Any())//se os criterios de recolecta non teñen ningunha parte e so temos un nivel, solo recollemos ese elemento
                {
                    elementosRecolectados.Add(coincidencia.Groups[0].Value);//O primeiro grupo vai a conter a primeira coincidencia, sin ningun nivel de granuralidade
                }
                else //si temos algun nivel de granuralidade, con elementos que teñen varias partes (como listas ul e similares)
                {
                    foreach (var parte in criteriosRecolecta.Partes)
                    {
                        Match parteCoincidente = Regex.Match(coincidencia.Groups[0].Value, parte.Regex, parte.OpcionsRegex); //de ese elemento con varias partes, imos recolectar certas partes

                        if (parteCoincidente.Success)//se obtemos valores ahi, estamos no segundo nivel (os li nunha lista ul por exemplo)
                        {
                            elementosRecolectados.Add(parteCoincidente.Groups[1].Value);//se hai algunha parte no segundo nivel, enton poñemola na lista de elementos recolectados
                        }
                    }
                }
            }

            return elementosRecolectados;//feito todo isto devolvemos os datos recollidos
        }
    }
}
