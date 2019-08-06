using System;
using Token.Domain.Entity;
using Token.Domain.Interfaces;
using Xunit;
using Moq;
using Token.Presentation;
using Token.Domain;

namespace XUnitTestProject1
{
    /// <summary>
    /// This tests are using XUnit
    /// </summary>
    public class DomainUnitTest
    {
        /// <summary>
        /// Validate Domain using interface and Moq.
        /// </summary>
        [Fact]
        public void GenerateTest()
        {
            TokenEntity tokenEntity = new TokenEntity();
            tokenEntity.SetCard(1111222233334444, DateTime.Now, 123);

            var mockIToken = new Mock<IToken>();
            mockIToken.Setup(x => x.Generate(tokenEntity)).Returns("1111222233334444");

            string token = mockIToken.Object.Generate(tokenEntity);
            
            Assert.Equal("1111222233334444", token);
        }

        /// <summary>
        /// Validate Domain method.
        /// </summary>
        [Fact]
        public void Generate2Test()
        {
            TokenEntity tokenEntity = new TokenEntity();
            tokenEntity.SetCard(1111222233334444, DateTime.Now, 123);

            GenerateToken generateToken = new GenerateToken();
            var token = generateToken.Generate(tokenEntity);

            var verify = generateToken.Validate(token, tokenEntity);

            Assert.True(verify);
        }
    }
}
