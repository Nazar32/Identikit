using Identikit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class, Idenfiable, new()
    {
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            using (var context = new IdentikitContext()) 
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public bool Delete(TEntity entity)
        {
            var result = false;
            using (var context = new IdentikitContext())
            {
                try
                {
                    context.Set<TEntity>().Remove(entity);
                    result = true;
                }
                catch (InvalidOperationException)
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    result = true;
                }
                context.SaveChanges();
                return result;
            }
        }

        public TEntity GetById(Guid id)
        {
            using (var context = new IdentikitContext())
            {
                return context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            }
        }

        public void DeleteAll()
        {
            using (var context = new IdentikitContext())
            {
                foreach (var id in context.Set<TEntity>().Select(e => e.Id))
                {
                    TEntity entityToRemove = new TEntity();
                    entityToRemove.Id = id;
                    try
                    {
                        context.Set<TEntity>().Remove(entityToRemove);
                    }
                    catch(InvalidOperationException)
                    {
                        context.Entry(entityToRemove).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                context.SaveChanges();
            }
        }

        public TEntity[] GetAll()
        {
            using (var context = new IdentikitContext())
            {
                return context.Set<TEntity>().ToArray();
            }
        }

        public int length
        {
            get
            {
                using (var context = new IdentikitContext())
                {
                    return context.Set<TEntity>().Count();
                }
            }
            set { }
        }
    }
}
