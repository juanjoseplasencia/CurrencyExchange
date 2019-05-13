using System;
using System.Collections.Generic;

namespace CurrencyExchange.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
    }
}
