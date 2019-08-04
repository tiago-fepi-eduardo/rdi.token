using FluentValidation;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Token.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Token.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IToken _token;

        /// <summary>
        /// Iniciate my dependy injection
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="token"></param>
        public BaseService(IRepository<T> repository, IToken token)
        {
            _repository = repository;
            _token = token;
        }

        /// <summary>
        /// Insert new token on the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Post(T obj)
        {
            try
            {
                var _obj = obj as TokenEntity;

                string token = _token.Generate(_obj);

                _repository.Insert(obj);

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check if token is valid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Put(string token, DateTime date)
        {
            try
            {
                // Get data from database based on date informed by user.
                // If it's longer then 15 minutes behind, i will be false.
                var obj = Get(date);

                if (obj != null)
                {
                    TokenEntity tokenFromBase = obj as TokenEntity;

                    // Join data from user interface and join data from database
                    //tokenInformed.SetCard(tokenFromBase.CardNumber, tokenFromBase.Date, tokenFromBase.CVV);

                    // Send token informed on the user interface and compare to token from data saved on the database.
                    return _token.Validate(token, tokenFromBase);
                } else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get data used to generate a token from database
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public T Get(DateTime date)
        {
            try
            {
                return _repository.Select(date);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}