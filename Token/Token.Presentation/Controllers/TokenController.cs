using Microsoft.AspNetCore.Mvc;
using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Token.Infra.CrossCutting;
using Token.Presentation.Model;

namespace Token.Presentation.Controllers
{
    /// <summary>
    /// API controller to generate token.
    /// </summary>
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IService<BaseEntity> _service;
        
        /// <summary>
        /// Dependency injection to access Service layer.
        /// </summary>
        /// <param name="Service"></param>
        public TokenController(IService<BaseEntity> Service)
        {
            _service = Service;
        }

        /// <summary>
        /// Request a new valid token and return it to user interface.
        /// </summary>
        /// <param name="token"></param>
        // POST api/token
        [HttpPost]
        public string Post([FromBody]TokenModel token)
        {
            if (!ValidateHelper.ValidateCreditCardNumber(token.CardNumber))
                throw new Exception("CardNumber not correct format");

            TokenEntity tokenEntity = new TokenEntity();
            tokenEntity.SetCard(token.CardNumber, token.Date, token.CVV);

            return _service.Post(tokenEntity);
        }

        // GET, PUT AND DELETE not used in this solution.

    }
}
