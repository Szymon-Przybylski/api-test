using API.Exceptions.Abstract;

namespace API.Exceptions.Concrete
{
    public class DataNotFoundException : AppException
    {
        public int StatusCode { get; }
        public DataNotFoundException(int statusCode) : base($"Get data result kiranico exception exited with code {statusCode}")
        {
            StatusCode = statusCode;
        }

        public override string Code => "get_file_result_exception";
    }
}