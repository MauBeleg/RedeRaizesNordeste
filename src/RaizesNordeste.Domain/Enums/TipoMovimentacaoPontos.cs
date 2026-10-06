using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<TipoMovimentacaoPontos>))]
    public enum TipoMovimentacaoPontos
    {
        Credito,
        Resgate,
        Estorno
    }
}