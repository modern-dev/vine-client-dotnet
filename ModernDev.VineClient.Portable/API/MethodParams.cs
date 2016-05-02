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
using System.Collections.Generic;
using ModernDev.VineClient.API.Exceptions;

namespace ModernDev.VineClient.API
{
    internal class MethodParams : List<Tuple<string, object, bool>>
    {
        public Dictionary<string, string> GetParams()
        {
            var prms = new Dictionary<string, string>();

            foreach (var seq in this)
            {
                string actualVal;

                if (seq.Item3 && seq.Item2 == null)
                {
                    throw new VineClientException($"Required parameter {seq.Item1} can not be null.");
                }

                if (seq.Item2 is bool)
                {
                    actualVal = seq.Item3 ? "1" : "0";
                }
                else
                {
                    actualVal = seq.ToString();
                }

                prms.Add(seq.Item1, actualVal);
            }

            return prms;
        }
    }
}