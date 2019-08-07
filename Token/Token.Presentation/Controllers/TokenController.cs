using Microsoft.AspNetCore.Mvc;
using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Token.Presentation.Model;

namespace Token.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : BaseController
    {
        private readonly IService<BaseEntity> _service;

        /// <summary>
        /// Dependency injection to access Service layer.
        /// </summary>
        /// <param name="Service"></param>
        public TokenController(IService<BaseEntity> Service) : base()
        {
            _service = Service;
        }

        /// <summary>
        /// Request a new valid token and return it to user interface.
        /// </summary>
        /// <param name="token"></param>
        // POST api/token
        //Route not necessary in this case
        [HttpPost]
        public ActionResult Post([FromBody]TokenModel token)
        {
            try {
                TokenEntity tokenEntity = new TokenEntity();
                tokenEntity.SetCard(token.CardNumber, token.Date, token.CVV);

                return Response(true, _service.Post(tokenEntity));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }

        // GET, PUT AND DELETE not used in this solution.
        
        //Trocar nome do projeto presentaion para API
        //Criar retorno padrao
        //Implementar validation na Service
        //Tirar da CrossCut a validacao de CPF.
        //Adicionar na crosscut um log.
        //Impolementar dispose no IRepository
        //Criar metodo para resolve injecao de Dep. na teste.
        //Resolver Docker
    }
}
