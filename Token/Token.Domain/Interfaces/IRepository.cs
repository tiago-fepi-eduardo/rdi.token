using Token.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Token.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        T Select(DateTime date);
    }
}
