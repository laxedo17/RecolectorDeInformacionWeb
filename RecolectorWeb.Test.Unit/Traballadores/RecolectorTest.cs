using Microsoft.VisualStudio.TestTools.UnitTesting;

using RecolectorDeInformacionWeb.Datos;
using RecolectorDeInformacionWeb.Traballadores;

using System.Text.RegularExpressions;

namespace RecolectorWeb.Test.Unit
{
    [TestClass]
    public class RecolectorTest
    {
        private readonly Recolector _recolector = new Recolector();

        [TestMethod]
        public void AtopaColeccionSenSegmentos()
        {
            var contido = "Datos sen importancia <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> datos sen importancia";

            CriteriosRecolecta criteriosRecolecta = new CriteriosRecolectaBuilder()
                .ConDatos(contido)
                .ConRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .ConOpcionsRegex(RegexOptions.ExplicitCapture)
                .Build();

            var elementosAtopados = _recolector.Recolecta(criteriosRecolecta);

            Assert.IsTrue(elementosAtopados.Count == 1);
            Assert.IsTrue(elementosAtopados[0] == "<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">un texto</a>");
        }

        [TestMethod]
        public void AtopaColeccionConDuasPartes()
        {
            var contido = "Datos calquera <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> mais datos calquera";

            CriteriosRecolecta criteriosRecolecta = new CriteriosRecolectaBuilder()
                .ConDatos(contido)
                .ConRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
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

            var foundElements = _recolector.Recolecta(criteriosRecolecta);

            Assert.IsTrue(foundElements.Count == 2);
            Assert.IsTrue(foundElements[0] == "un texto");
            Assert.IsTrue(foundElements[1] == "http://domain.com");
        }
        
    }
}
