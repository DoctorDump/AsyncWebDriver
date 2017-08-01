// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

using System;
using System.Runtime.Serialization;

namespace Zu.AsyncWebDriver
{
    /// <summary>
    ///     The exception that is thrown when a frame is not found.
    /// </summary>
    [Serializable]
    public class NoSuchFrameException : NotFoundException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NoSuchFrameException" /> class.
        /// </summary>
        public NoSuchFrameException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoSuchFrameException" /> class with
        ///     a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NoSuchFrameException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoSuchFrameException" /> class with
        ///     a specified error message and a reference to the inner exception that is the
        ///     cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception,
        ///     or <see langword="null" /> if no inner exception is specified.
        /// </param>
        public NoSuchFrameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoSuchFrameException" /> class with serialized data.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected NoSuchFrameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}