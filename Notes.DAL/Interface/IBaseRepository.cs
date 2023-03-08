namespace Notes.DAL.Interface
{
    public interface IBaseRepository<T>
    {
        public Task Create(T entity);
        public Task<List<T>> Get();
        public Task<T> Update(T entity);
        public Task Delete(T entity);
    }
}
