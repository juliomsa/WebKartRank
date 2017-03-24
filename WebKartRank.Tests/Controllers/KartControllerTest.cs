using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebKartRank.Models;

namespace WebKartRank.Tests.Controllers
{
    [TestClass]
    public class KartControllerTest
    {
        [TestMethod]
        public void ValidarInclusao()
        {
            TimeSpan hora_chegada = new TimeSpan(0, 23, 49, 8, 277);
            string codigo_piloto = "038";
            string nome_piloto = "F.MASSA";
            int nr_volta = 1;
            TimeSpan tempo_volta = new TimeSpan(0, 0, 1, 2, 852);
            double media_volta = 44.275;

            Kart obj = new Kart();
            obj.hora_chegada = hora_chegada;
            obj.codigo_piloto = codigo_piloto;
            obj.nome_piloto = nome_piloto;
            obj.nr_volta = nr_volta;
            obj.tempo_volta = tempo_volta;
            obj.media_volta = media_volta;

            Assert.IsNotNull(hora_chegada);
            Assert.IsNotNull(codigo_piloto);
            Assert.IsNotNull(nome_piloto);
            Assert.IsNotNull(nr_volta);
            Assert.IsNotNull(tempo_volta);
            Assert.IsNotNull(media_volta);
        }
    
    }
}
