using FluentValidation;
using FluentValidation.Results;
using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Token.Infra.CrossCutting;
using Token.Service.Validation;

namespace Token.Service.Services
{
    public class TokenService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IToken _token;

        /// <summary>
        /// Iniciate my dependy injection
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="token"></param>
        public TokenService(IRepository<T> repository, IToken token)
        {
            _repository = repository;
            _token = token;
        }

        /// <summary>
        /// Insert new token on the database
        /// Example of validate the entity using Abstract Validator
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Post(T obj)
        {
            try
            {
                var result = Validate(obj);

                if (!result.IsValid)
                    throw new ExecptionHelper.ExceptionService(result.Errors[0].ToString());

                var _obj = obj as TokenEntity;

                string token = _token.Generate(_obj);

                _repository.Insert(obj);

                return token;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
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
                var validator = new TokenValidator().ValidateDecode(token, date);

                if (!String.IsNullOrEmpty( validator.ErrorMessage))
                    throw new ExecptionHelper.ExceptionService(validator.ErrorMessage);

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
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
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
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected ValidationResult Validate(T obj)
        {
            var validator = new TokenValidator().Validate((TokenEntity)(Object)obj);

            return validator;
        }
    }
}