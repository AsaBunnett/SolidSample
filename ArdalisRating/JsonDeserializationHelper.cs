using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArdalisRating;

public class JsonDeserializationHelper<T>
{
    private JsonSerializerOptions options = new()
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public T DeserializeString(string stringToDeserialize)
    {
        return JsonSerializer.Deserialize<T>(stringToDeserialize, options);
    }
}