using Notes.Domain.Enum;

namespace Notes.Domain.Interface
{
    public interface IBaseResponse<T>
    {
        StatusCode StatusCode { get; }
        public T Data { get; }

    }
}
