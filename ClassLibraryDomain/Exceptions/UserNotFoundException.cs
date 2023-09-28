using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int id) : base($"User id: {id}, user not found.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
