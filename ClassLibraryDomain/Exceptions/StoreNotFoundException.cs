using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Exceptions
{
    public class StoreNotFoundException : Exception
    {
        public StoreNotFoundException(int id) : base($"Tienda id: {id}, tienda no encontrada.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected StoreNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
