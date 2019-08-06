using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Token.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class DecodeController : Controller
    {
        private readonly IService<BaseEntity> _service;

        /// <summary>
        /// Dependency injection to access Service layer.
        /// </summary>
        /// <param name="Service"></param>
        public DecodeController(IService<BaseEntity> Service)
        {
            _service = Service;
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

        // POST, GET and DELETE not impplemented
    }
}
