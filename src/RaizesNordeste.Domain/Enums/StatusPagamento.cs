using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<StatusPagamento>))]
    public enum StatusPagamento
    {
        Pendente,
        Aprovado,
        Recusado
    }
}