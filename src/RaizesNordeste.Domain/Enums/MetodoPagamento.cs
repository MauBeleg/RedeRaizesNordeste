using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<MetodoPagamento>))]
    public enum MetodoPagamento
    {
        Pix,
        Credito,
        Debito
    }
}