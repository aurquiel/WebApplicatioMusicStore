using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Exceptions
{
    internal class UserLoginException : Exception
    {
        public UserLoginException(string alias) : base($"Usuario: {alias}, crendciales incorrectas.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected UserLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
