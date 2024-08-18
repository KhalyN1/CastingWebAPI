namespace CastingWebAPI.Interfaces
{
    public interface IMongoRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetAsync(Guid id);

        public Task<T> AddOneAsync(T entity);

        public Task DeleteAsync(Guid id);

        public Task<T> UpdateAsync(Guid id, T entity);
    }
}
