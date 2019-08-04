using System;
using System.Collections.Generic;
using System.Text;
using Token.Domain.Entity;

namespace Token.Domain.Interfaces
{
    public interface IToken
    {
        bool Validate(string tokenInformed, TokenEntity tokenEntity);
        string Generate(TokenEntity tokenEntity);
    }
}
