using Notes.Domain.Enum;

namespace Notes.Domain.Interface
{
    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        public T Data { get; }

    }
}
