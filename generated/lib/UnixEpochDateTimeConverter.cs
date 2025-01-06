// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// <auto-generated />
#nullable enable

using System.Text.Json;
using System.Text.Json.Serialization;

namespace TypeSpec.Helpers.JsonConverters
{
    /// <summary>
    /// Converts between an integer timestamp and a .Net DateTime
    /// </summary>
    public sealed class UnixEpochDateTimeConverter : JsonConverter<DateTime>
    {
        static readonly DateTime s_epoch = new DateTime(1970, 1, 1, 0, 0, 0);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var formatted = reader.GetInt64()!;
            return s_epoch.AddMilliseconds(formatted);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTime = Convert.ToInt64((value - s_epoch).TotalMilliseconds);
            writer.WriteNumberValue(unixTime);
        }
    }
}
