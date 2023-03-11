namespace Notes.DAL.Interface
{
    public interface IBaseRepository<T>
    {
        public Task Create(T entity);
        public IQueryable<T> GetAll();
        public Task<T> Update(T entity);
        public Task Delete(T entity);
    }
}
