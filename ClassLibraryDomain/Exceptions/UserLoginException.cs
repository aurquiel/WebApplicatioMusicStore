using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClassLibraryDomain.Exceptions
{
    public class UserLoginException : Exception
    {
        public UserLoginException(string alias) : base($"Usuario: {alias}, credenciales incorrectas.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected UserLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
