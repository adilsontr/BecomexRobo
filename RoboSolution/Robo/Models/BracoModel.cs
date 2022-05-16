using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Robo.Models
{
    public class BracoModel
    {
        public enum Cotovelo
        {
            Em_Repouso = 1,
            Levemente_Contraido = 2,
            Contraido = 3,
            Fortemente_Contraido = 4
        }

        public enum Pulso
        {
            Rotacao_90_Negativo = 1,
            Rotacao_45_negativo = 2,
            Em_Repouso = 3,
            Rotação_45 = 4,
            Rotação_90 = 5,
            Rotação_135 = 6,
            Rotação_180 = 7
        }

        public Pulso pulsoBraco { get; set; }
        public Cotovelo cotoveloBraco { get; set; }

    }
}