using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Xunit;
using Token.Service.Services;
using Moq;

namespace XUnitTestProject1
{
    public class TokenServiceUnitTest
    {
        private IService<BaseEntity> _service;
        
        public TokenServiceUnitTest()
        {
            var mockIToken = new Mock<IToken>().Object;
            
            var mockIRep = new Mock<IRepository<BaseEntity>>().Object;
            
            _service = new TokenService<BaseEntity>(mockIRep, mockIToken);
        }

        [Fact]
        public void PostTest()
        {
            TokenEntity tokenEntity = new TokenEntity();
            tokenEntity.SetCard(1111222233334444, DateTime.Now, 123);

            var token = _service.Post(tokenEntity);

            var verify = _service.Put(token, DateTime.Now);

            Assert.True(verify);
        }
    }
}
