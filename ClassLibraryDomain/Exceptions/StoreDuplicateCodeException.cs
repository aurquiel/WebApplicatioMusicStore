using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Exceptions
{
    public class StoreDuplicateCodeException : Exception
    {
        public StoreDuplicateCodeException(string code) : base($"Tienda codigo: {code} ya existe.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected StoreDuplicateCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
