namespace Notes.DAL.Interface
{
    public interface IBaseRepository<T>
    {
        public Task Create(T entity);
        public Task<List<T>> Get();
        public Task<bool> Update(T entity);
        public Task<bool> Delete(T entity);
    }
}
