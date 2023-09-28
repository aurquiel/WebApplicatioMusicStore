using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ClassLibraryDomain.Exceptions
{
    public class AudioMaxCapacityException : Exception
    {
        public AudioMaxCapacityException(double maxCapacity) : base($"Maxima capadicad alcanzada: {maxCapacity} Mb. Elimine audios para agregar nuevos audios.")
        {

        }

        [ExcludeFromCodeCoverage]
        protected AudioMaxCapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
