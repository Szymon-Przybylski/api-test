using System;

namespace API.Exceptions.Abstract
{
    public abstract class AppException : Exception
    {
        public abstract string Code { get; }

        protected AppException(string message) : base(message)
        {
        }
    }
}