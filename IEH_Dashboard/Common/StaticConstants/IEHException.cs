namespace IEH_Dashboard.Common.StaticConstants
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="IEHException" />
    /// </summary>
    [Serializable]
    public class IEHException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IEHException"/> class.
        /// </summary>
        /// <param name="info">The info<see cref="SerializationInfo"/></param>
        /// <param name="context">The context<see cref="StreamingContext"/></param>
        protected IEHException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEHException"/> class.
        /// </summary>
        public IEHException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEHException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public IEHException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEHException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="inner">The inner<see cref="Exception"/></param>
        public IEHException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
