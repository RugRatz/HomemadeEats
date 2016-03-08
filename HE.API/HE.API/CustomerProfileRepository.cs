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
    public class CustomerProfileRepository : HERepository<CustomerProfile>
    {
        public HE_DbContext _context { get; private set; }
        private DbSet<CustomerProfile> _set;
        public bool AutoSaveChanges { get; set; }
        public bool DisposeContext { get; set; }

        public CustomerProfileRepository(HE_DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("HE_DbContext");
            }
            _context = context;
            AutoSaveChanges = true;
        }

        protected DbSet<CustomerProfile> Set
        {
            get { return _set ?? (_set = _context.Set<CustomerProfile>()); }
        }

        public IQueryable<CustomerProfile> Users
        {
            get { return _context.Set<CustomerProfile>(); }
        }

        public List<CustomerProfile> GetAll()
        {
            return Set.ToList();
        }

        public Task<List<CustomerProfile>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public Task<List<CustomerProfile>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Set.ToListAsync(cancellationToken);
        }

        public List<CustomerProfile> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<CustomerProfile>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<CustomerProfile>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public CustomerProfile FindById(object id)
        {
            return Set.Find(id);
        }

        //Task<CustomerProfile> IRepository<CustomerProfile>.FindByIdAsync(object id)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<CustomerProfile> FindByIdAsync(object id)
        {
            return Set.FindAsync(id);
        }

        public Task<CustomerProfile> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            return Set.FindAsync(cancellationToken, id);
        }

        public void Add(CustomerProfile entity)
        {
            Set.Add(entity);
        }

        public void Update(CustomerProfile entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(CustomerProfile entity)
        {
            Set.Remove(entity);
        }

        //private Task<TEntity> GetUserAggregateAsync(Expression<Func<TEntity, bool>> filter)
        //{
        //    return Users.AsQueryable().Include(u => u).FirstOrDefaultAsync(filter);
        //}
    }
}