using System.Text.Json;
using System.Text.Json.Serialization;

namespace backTOT
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy/MM/dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Parse chuỗi vào DateOnly
            return DateOnly.ParseExact(reader.GetString(), Format);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            // Chuyển DateOnly thành chuỗi với định dạng mong muốn
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
