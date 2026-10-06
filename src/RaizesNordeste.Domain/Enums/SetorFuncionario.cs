using System.Text.Json.Serialization;

namespace RaizesNordeste.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter<SetorFuncionario>))]
    public enum SetorFuncionario
    {
        Atendimento,
        Cozinha,
        Gerencia
    }
}