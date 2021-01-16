using RecolectorDeInformacionWeb.Datos;
using RecolectorDeInformacionWeb.Traballadores;

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

using static System.Console;

namespace RecolectorDeInformacionWeb
{
    class Program
    {

        private const string Metodo = "search";
        static void Main(string[] args)
        {
            try
            {
                WriteLine("Escribe a cidade da que queres obter informacion: ");

                var cidadeCraigslist = ReadLine() ?? string.Empty; //se o usuario non escribe nada usamos un string vacio

                WriteLine("Indica a categoria de Craiglista da que che gustaria recolectar datos: ");

                var nomeCategoriaCraigslist = ReadLine() ?? string.Empty;

                using (WebClient cliente = new WebClient())
                {
                    string contido = cliente.DownloadString($"http://{cidadeCraigslist.Replace(" ", string.Empty)}.craigslist.org/{Metodo}/{nomeCategoriaCraigslist}");//se o usuario escribe New York por exemplo, quitamoslle o espacio para que na direccion de internet apareza NewYork (que e como o escribe Craiglist) e non New York

                    CriteriosRecolecta criteriosRecolecta = new CriteriosRecolectaBuilder()
                        .ConDatos(contido)
                        // craigslist agregou recentemente unha id o seu grupo de elementos, en maio de 2020, incluida aqui tb
                        .ConRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"" id=\""(.*?)\"" >(.*?)</a>")
                        .ConOpcionsRegex(RegexOptions.ExplicitCapture)
                        .ConParte(new ParteCriterioRecolectaBuilder()
                            .ConRegex(@">(.*?)</a>")
                            .ConOpcionsRegex(RegexOptions.Singleline)
                            .Build())
                        .ConParte(new ParteCriterioRecolectaBuilder()
                            .ConRegex(@"href=\""(.*?)\""")
                            .ConOpcionsRegex(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Recolector recolector = new Recolector();

                    var elementosRecolectados = recolector.Recolecta(criteriosRecolecta);

                    if (elementosRecolectados.Any())
                    {
                        foreach (var elementoRecolectado in elementosRecolectados)
                        {
                            WriteLine(elementoRecolectado);
                        }
                    }
                    else
                    {
                        WriteLine("Non hai coincidencia para o teu criterio de recollida de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            

        }
    }
}
