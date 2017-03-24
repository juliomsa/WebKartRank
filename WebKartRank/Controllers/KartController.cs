using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace WebKartRank.Controllers
{
    public class KartController : Controller
    {
        // GET: Kart
        public ActionResult Index()
        {

            List<Models.Kart> lstKart = new List<Models.Kart>();

            int iLinha = 1; //cabecalho

            StreamReader sr = new StreamReader(Server.MapPath("~/kart.txt"));

            while (!sr.EndOfStream)
            {
                string sLinhaToda = ConverteToUTF8(sr.ReadLine()).Replace("\t\t", "\t").Replace("\t\t", "\t").Replace("\t  \t", "\t");
                string[] sLinha = sLinhaToda.Split('\t');

                if (iLinha > 1)
                {
                    lstKart.Add(
                        new Models.Kart
                        {
                            hora_chegada = TimeSpan.Parse(sLinha[0]),
                            codigo_piloto = sLinha[1].Split('?')[0].Trim(),
                            nome_piloto = sLinha[1].Split('?')[1].Trim(),
                            nr_volta = int.Parse(sLinha[2]),
                            tempo_volta = TimeSpan.Parse("00:" + sLinha[3]),
                            media_volta = double.Parse(sLinha[4])
                        });
                }
                iLinha++;
            }

            var classificacao = lstKart
                                    .GroupBy(t1 => new { t1.codigo_piloto })
                                    .Select(t2 =>
                                      new Models.Kart
                                      {
                                          codigo_piloto = t2.Key.codigo_piloto,
                                          nome_piloto = lstKart.Where(c => t2.Key.codigo_piloto == c.codigo_piloto).FirstOrDefault().nome_piloto,
                                          qtde_voltas = lstKart.Where(c => t2.Key.codigo_piloto == c.codigo_piloto).Max(c1 => c1.nr_volta),
                                          tempo_prova = lstKart.Where(c => t2.Key.codigo_piloto == c.codigo_piloto).Sum(d => d.tempo_volta.Ticks),
                                          melhor_volta = lstKart.Where(c => t2.Key.codigo_piloto == c.codigo_piloto).Min(e => e.tempo_volta),
                                          veloc_media = lstKart.Where(c => t2.Key.codigo_piloto == c.codigo_piloto).Average(f => f.media_volta),
                                          hora_chegada = lstKart.Where(c => t2.Key.codigo_piloto == c.codigo_piloto).OrderByDescending(g => g.hora_chegada).FirstOrDefault().hora_chegada,
                                          melhor_volta_geral = lstKart.Min(e => e.tempo_volta),
                                      })
                                    .OrderBy(fim => fim.hora_chegada)
                                    .ToList()
                                    .Select((t3, i) =>
                                        new Models.Kart
                                        {
                                            posicao = i + 1,
                                            codigo_piloto = t3.codigo_piloto,
                                            nome_piloto = t3.nome_piloto,
                                            qtde_voltas = t3.qtde_voltas,
                                            tempo_prova = t3.tempo_prova,
                                            melhor_volta = t3.melhor_volta,
                                            veloc_media = t3.veloc_media,
                                            hora_chegada = t3.hora_chegada,
                                            melhor_volta_geral = t3.melhor_volta_geral,
                                            tempo_apos = t3.hora_chegada.Subtract((lstKart.Where(c => c.nr_volta.Equals(4)).Min(d => d.hora_chegada)))
                                        });


            return View("Kart", classificacao.ToList());
        }

        public string ConverteToUTF8(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}