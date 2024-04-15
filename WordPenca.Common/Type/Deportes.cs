
using System.Text.Json.Serialization;

namespace Products.Common.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Deportes
{
    Futbol,
    Basquebol,
    Tenis
}