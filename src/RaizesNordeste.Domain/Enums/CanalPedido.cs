using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<CanalPedido>))]
    public enum CanalPedido
    {
        App,
        Web,
        Totem,
        Balcao,
        Pickup
    }
}