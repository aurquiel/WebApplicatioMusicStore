using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Exceptions
{
    public class AudioNotFoundException : Exception
    {
        public AudioNotFoundException(string audioName) : base($"Audio: {audioName}, audio no encontrado.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected AudioNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
