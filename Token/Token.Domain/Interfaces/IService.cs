using FluentValidation;
using System;
using Token.Domain.Entity;

namespace Token.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        string Post(T obj);
        bool Put(string token, DateTime date);
    }
}
