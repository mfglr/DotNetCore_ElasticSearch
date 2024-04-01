using System.Net;

namespace NestLibrary.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message, HttpStatusCode httpStatusCode): base(message) {
            HttpStatusCode = httpStatusCode;
        }
        public HttpStatusCode HttpStatusCode { get; private set; }
    }
}
