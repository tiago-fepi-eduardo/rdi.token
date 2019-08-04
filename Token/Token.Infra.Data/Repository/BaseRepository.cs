using Token.Domain.Interfaces;
using Token.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Token.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TokenContext _context;

        public BaseRepository(TokenContext context)
        {
            _context = context;
        }
        
        public void Insert(T obj)
        {
            try
            {
                _context.Set<T>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public T Select(DateTime date)
        {
            try
            {
                var item = _context.Tokens.Where(x => x.Date > (date.AddMinutes(-15))).OrderByDescending(x => x.Date).FirstOrDefault();

                return item as T;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
