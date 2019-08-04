using Microsoft.AspNetCore.Mvc;
using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
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
            TokenEntity tokenEntity = new TokenEntity();
            tokenEntity.SetCard(token.CardNumber, token.Date, token.CVV);

            return _service.Post(tokenEntity);
        }

        /// <summary>
        /// Check if the token is valid and return to user interface.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="date"></param>
        // PUT api/token
        [HttpPut]
        public bool Put(string token, DateTime date)
        {
            TokenEntity tokenEntity = new TokenEntity();

            return _service.Put(token, date);
        }

        // GET AND DELETE not used in this solution.

    }
}
