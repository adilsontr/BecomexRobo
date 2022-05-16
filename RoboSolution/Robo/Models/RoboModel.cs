using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Robo.Models
{
    public class RoboModel
    {        
        public CabecaModel cabeca { get; set; }
        public BracoModel bracoDireito { get; set; }
        public BracoModel bracoEsquerdo { get; set; }

        public RoboModel()
        {
            cabeca = new CabecaModel();
            bracoDireito = new BracoModel();
            bracoEsquerdo = new BracoModel();

            cabeca.inclinacaoCabeca = CabecaModel.Inclinacao.Em_Repouso;
            cabeca.rotacaoCabeca = CabecaModel.Rotacao.Em_Repouso;

            bracoDireito.pulsoBraco = BracoModel.Pulso.Em_Repouso;
            bracoEsquerdo.pulsoBraco = BracoModel.Pulso.Em_Repouso;

            bracoDireito.cotoveloBraco = BracoModel.Cotovelo.Em_Repouso;
            bracoEsquerdo.cotoveloBraco = BracoModel.Cotovelo.Em_Repouso;
        }

        public Boolean validarMovimento(int atual, int novo)
        {
            if(!((novo == (atual + 1)) || (novo == (atual - 1))))
            {
                throw new Exception("Movimento invalido");
            }
            return true;
        }

        public Boolean movimentarPulso(BracoModel braco)
        {
            if(!BracoModel.Cotovelo.Fortemente_Contraido.Equals(braco.cotoveloBraco))
            {
                throw new Exception("Só pode mover o Pulso se o Cotovelo estiver Fortemente Contraído");
            }
            return true;
        }

        public Boolean movimentoCabeca()
        {
            if (CabecaModel.Inclinacao.Para_Baixo.Equals(cabeca.inclinacaoCabeca))
            {
                throw new Exception("Movimento de rotação da cabeça somente se a cabeça não estiver para baixo");
            }
            return true;
        }

        public Boolean validarInclinacaoCabeca(int movimento)
        {   
            if (!Enum.IsDefined(typeof(CabecaModel.Inclinacao), movimento))
            {
                throw new Exception("Movimento inexistente");
            }
            return true;
        }
        public Boolean validarRotacaoCabeca(int movimento)
        {            
            if (!Enum.IsDefined(typeof(CabecaModel.Rotacao), movimento))
            {
                throw new Exception("Movimento de Rotação inexistente");
            }
            return true;
        }


        public Boolean validarMovimentoPulso(int movimento)
        {
            if (!Enum.IsDefined(typeof(BracoModel.Pulso), movimento))
            {
                throw new Exception("Movimento de Pulso inexistente");
            }
            return true;

            
        }
        public Boolean validarMovimentoCotovelo(int movimento)
        {
            if (!Enum.IsDefined(typeof(BracoModel.Cotovelo), movimento))
            {
                throw new Exception("Movimento de Cotovelo inexistente");
            }
            return true;
        }

    }
}