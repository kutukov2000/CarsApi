using System.Net;

namespace BusinessLogic.Exceptions
{

    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpException() { }
        public HttpException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
        public HttpException(string message, HttpStatusCode statusCode, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }
        protected HttpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}