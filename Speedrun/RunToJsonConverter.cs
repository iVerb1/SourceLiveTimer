using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SourceLiveTimer.Speedrun
{
    class RunJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsClass;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Run run = (Run)value;

            writer.WriteStartObject();
            writer.WritePropertyName("Category");
            serializer.Serialize(writer, run.Category.Name);
            writer.WritePropertyName("RunName");
            serializer.Serialize(writer, run.Name);
            writer.WritePropertyName("Splits");
            writer.WriteStartArray();
            for (int i = 0; i < run.Count; i++)
            {
                serializer.Serialize(writer, run[i]);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
             throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead
        {
            get { return false; }
        }
    }
}
