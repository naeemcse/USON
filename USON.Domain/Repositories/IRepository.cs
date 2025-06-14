using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USON.Domain.Entities;

namespace USON.Domain.Repositories
{
    public interface IRepository<TEntity,TKey> where TEntity : class ,IEntity<TKey> where TKey:IComparable
    {
        void Add (TEntity entity);
        Task AddAsync (TEntity entity);
        void Edit (TEntity entity);
        void Delete (TKey id);
        IList<TEntity> GetAll ();

        TEntity GetById (TKey id);
    }
}
