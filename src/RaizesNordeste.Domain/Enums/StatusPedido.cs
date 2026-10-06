using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<StatusPedido>))]
    public enum StatusPedido
    {
        AguardandoPagamento,
        Recebido,
        EmPreparo,
        Pronto,
        Entregue,
        Cancelado
    }
}