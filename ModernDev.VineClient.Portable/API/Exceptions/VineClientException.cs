/**
 * This file\code is part of VineClient project.
 *
 * VineClient - is an unofficial C# library for the Vine.
 * https://github.com/modern-dev/vine-client-dotnet
 *
 * Copyright (c) 2016 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System;

namespace ModernDev.VineClient
{
    public class VineClientException : Exception
    {
        public object Detail { get; private set; }
        public VineClientException(string message) : base(message) { }
        public VineClientException(string message, Exception innerException) : base(message, innerException) { }

        public VineClientException(string message, object detail) : base(message)
        {
            Detail = detail;
        }
    }
}