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
        public StoreNotFoundException(int id) : base($"Store id: {id}, store not found.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected StoreNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
