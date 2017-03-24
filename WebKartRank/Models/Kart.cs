using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebKartRank.Models
{
    public class Kart
    {
        public TimeSpan hora_chegada { get; set; }
        public string codigo_piloto { get; set; }
        public string nome_piloto { get; set; }
        public int nr_volta { get; set; }
        public TimeSpan tempo_volta { get; set; }
        public double media_volta { get; set; }

        public int posicao { get; set; }
        public int qtde_voltas { get; set; }
        public long tempo_prova { get; set; }
        public TimeSpan melhor_volta { get; set; }
        public TimeSpan melhor_volta_geral { get; set; }
        public double veloc_media { get; set; }
        public TimeSpan tempo_apos { get; set; }
    }


}