using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Robo.Models;

namespace RoboAPI.Controllers
{
    public class RoboController : ApiController
    {
        // GET: api/Robo
        public RoboModel Get()
        {
            return new RoboModel();
        }
        [HttpPost]
        //[HttpGet]
        [Route("api/Robo/PostMovimento", Name = "PostMovimento")]
        //        public RoboModel PostMovimento([FromBody]int movimento, [FromBody] byte movimentos, [FromBody]RoboModel roboModel)
        public RoboModel PostMovimento(PostRequestRoboModel requestRoboModel)

        {
            RoboModel roboModel = requestRoboModel.roboModel;
            switch (requestRoboModel.tipoMovimento)
            {
                case MovimentosModel.Cabecainclinacao:
                    roboModel = CabecaInclinacao(requestRoboModel.movimento, roboModel);
                    break;
                case MovimentosModel.CabecaRotacao:
                    roboModel = CabecaRotacao(requestRoboModel.movimento, roboModel);
                    break;
                case MovimentosModel.CotoveloDireito:
                    roboModel.bracoDireito = Cotovelo(requestRoboModel.movimento, roboModel.bracoDireito, roboModel);
                    break;
                case MovimentosModel.CotoveloEsquerdo:
                    roboModel.bracoEsquerdo = Cotovelo(requestRoboModel.movimento, roboModel.bracoEsquerdo, roboModel);
                    break;
                case MovimentosModel.PulsoDireito:
                    roboModel.bracoDireito = Pulso(requestRoboModel.movimento, roboModel.bracoDireito, roboModel);
                    break;
                case MovimentosModel.PulsoEsquerdo:
                    roboModel.bracoEsquerdo = Pulso(requestRoboModel.movimento, roboModel.bracoEsquerdo, roboModel);
                    break;
                default:
                    throw new Exception("Tipo Movimento Invalido");
            }
            return roboModel;
        }

        #region .: Pulso :.

        private BracoModel Pulso(int movimento, BracoModel braco, RoboModel roboModel)
        {

            if (
                roboModel.validarMovimento((int)braco.pulsoBraco, movimento) &&
                roboModel.validarMovimentoPulso(movimento) &&
                roboModel.movimentarPulso(braco))
            {
                braco.pulsoBraco = (BracoModel.Pulso)movimento;
            }
            return braco;
        }


        #endregion

        #region .: Cotovelo :.

        private BracoModel Cotovelo(int movimento, BracoModel braco, RoboModel roboModel)
        {

            if (
                roboModel.validarMovimento((int)braco.cotoveloBraco, movimento) &&
                roboModel.validarMovimentoPulso(movimento))
            {
                braco.cotoveloBraco = (BracoModel.Cotovelo)movimento;
            }
            return braco;
        }

        #endregion

        #region .: Cabeca :.       

        private RoboModel CabecaRotacao(int movimento, RoboModel roboModel)
        {
            if (
                roboModel.validarMovimento((int)roboModel.cabeca.rotacaoCabeca, movimento) &&
                roboModel.movimentoCabeca())
            {
                roboModel.cabeca.rotacaoCabeca = (CabecaModel.Rotacao)movimento;
            }
            return roboModel;
        }


        private RoboModel CabecaInclinacao(int movimento, RoboModel roboModel)
        {

            if (roboModel.validarMovimento((int)roboModel.cabeca.inclinacaoCabeca, movimento))
            {
                roboModel.cabeca.inclinacaoCabeca = (CabecaModel.Inclinacao)movimento;
            }            

            return roboModel;
        }
        #endregion
    }
}
