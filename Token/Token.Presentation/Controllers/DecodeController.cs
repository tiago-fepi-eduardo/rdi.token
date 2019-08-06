using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Token.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class DecodeController : BaseController
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
        public ActionResult Put(string token, DateTime date)
        {
            try
            {
                TokenEntity tokenEntity = new TokenEntity();

                return Response(true, _service.Put(token, date));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }

        // POST, GET and DELETE not impplemented
    }
}
