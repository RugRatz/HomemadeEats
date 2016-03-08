using System;
using System.Collections.Generic;
using System.Linq;
using HE.DataAccess;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace HE.API
{
    public class HERepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public HE_DbContext _context { get; private set; }
        private DbSet<TEntity> _set;
        public bool AutoSaveChanges { get; set; }
        public bool DisposeContext { get; set; }

        public HERepository(HE_DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("HE_DbContext");
            }
            _context = context;
            AutoSaveChanges = true;
        }

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        public IQueryable<TEntity> Users
        {
            get { return _context.Set<TEntity>(); }
        }

        public List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Set.ToListAsync(cancellationToken);
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public TEntity FindById(object id)
        {
            return Set.Find(id);
        }

        Task<TEntity> IRepository<TEntity>.FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(object id)
        {
            return Set.FindAsync(id);
        }

        public Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            return Set.FindAsync(cancellationToken, id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }
    }
}