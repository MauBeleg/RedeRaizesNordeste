using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<TipoProduto>))]
    public enum TipoProduto
    {
        Preparado,
        Unitario
    }
}