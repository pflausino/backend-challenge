using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SquareMetersValue.Infra.Configurations;
using MongoDB.Driver.Linq;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.Infra.Interfaces;

namespace SquareMetersValue.Infra.Repositories
{
    public class Repository<TCollectionEntity, TType> : IRepository<TCollectionEntity, TType> where TCollectionEntity : Entity
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TCollectionEntity> DbSet;
        private readonly string EntityType;

        protected Repository(IMongoContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TCollectionEntity>(typeof(TCollectionEntity).Name.ToCamelCase());
            EntityType = typeof(TType).Name;
        }

        public virtual void Add(TCollectionEntity obj)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual async Task<TType> GetById(Guid id)
        {
            var filterById = Builders<TCollectionEntity>.Filter.Eq("_id", id);

            var data = await DbSet.FindAsync<TType>(filterById);
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TType>> GetAll()
        {
            var all = await DbSet.FindAsync<TType>(Builders<TCollectionEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<IEnumerable<TType>> GetByFilter(Expression<Func<TType, bool>> filter)
        {
            var filtered = DbSet.AsQueryable<TCollectionEntity>().OfType<TType>().Where(filter);
            return filtered.ToList();
        }

        //TODO: Talvez essa TCollectionEntity Tenha que mudar para a TType ????
        public virtual void Update(TCollectionEntity obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TCollectionEntity>.Filter.Eq("_id", obj.Id), obj));
        }

        public virtual void Remove(Guid id)
        {
            var filterByType = Builders<TCollectionEntity>.Filter.Eq("_t", EntityType);
            var filterById = Builders<TCollectionEntity>.Filter.Eq("_id", id);
            Context.AddCommand(() => DbSet.DeleteOneAsync(filterById & filterByType));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}