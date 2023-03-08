using Notes.Domain.Enum;

namespace Notes.Domain.Interface
{
    public interface IBaseResponse<T>
    {
        public T Data { get; }

    }
}
