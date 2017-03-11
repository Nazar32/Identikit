using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        bool Delete(TEntity entity);
        TEntity GetById(Guid id);
        void DeleteAll();
        TEntity[] GetAll();
        int length{ get; set; }
    }
}
