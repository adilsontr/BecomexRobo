using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Robo.Models
{
    public class CabecaModel
    {
      public enum Inclinacao 
        {
            Para_Cima = 1,
            Em_Repouso = 2,
            Para_Baixo = 3
        }

       public enum Rotacao
        {
            Rotacao_90_Negativo = 1,
            Rotacao_45_negativo = 2,
            Em_Repouso = 3,
            Rotação_45 = 4,
            Rotação_90 = 5
        }

        public Inclinacao inclinacaoCabeca { get; set; }
        public Rotacao rotacaoCabeca { get; set; }

    }
}