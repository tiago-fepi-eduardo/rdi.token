using System;
using Token.Domain.Entity;

namespace Token.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        //bool Post<V>(T obj) where V : AbstractValidator<T>;
        string Post(T obj);

        //bool Put<V>(T obj) where V : AbstractValidator<T>;
        bool Put(string token, DateTime date);
    }
}
