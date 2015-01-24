using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftp.InputCommand
{
    [Serializable]
    public class InputCommandNullAttributeException : System.ArgumentException
    {
        public InputCommandNullAttributeException()
        {
        }

        public InputCommandNullAttributeException(string message)
            : base(message)
        {
        }

        public InputCommandNullAttributeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InputCommandNullAttributeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {            
        }

    }
}
