using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable()]
    public class InvalidBlockException : Exception
    {
        public InvalidBlockException() : base("The block is invalid.") { }
        public InvalidBlockException(string message) : base(message) { }
        public InvalidBlockException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected InvalidBlockException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }

    public class BlockNotSignedException : Exception
    {
        public BlockNotSignedException() : base("The block is not signed.") { }
        public BlockNotSignedException(string message) : base(message) { }
        public BlockNotSignedException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected BlockNotSignedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }

    public class HashMismatchException : Exception
    {
        public HashMismatchException() : base("The PreviousBlockHash property of this block does not match the actual previous block hash.") { }
        public HashMismatchException(string message) : base(message) { }
        public HashMismatchException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected HashMismatchException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }

}
