
using Deshport.Domain.Enum;

namespace Deshport.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public Status StatusCode { get; set; }
        public T Data { get; set; }
    }
    public interface IBaseResponse<T>
    {       
        public Status StatusCode { get; }
        public T Data { get; }
    }
}
