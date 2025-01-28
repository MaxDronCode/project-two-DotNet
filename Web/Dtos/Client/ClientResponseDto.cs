using System.Text.Json.Serialization;

namespace Store.Controllers.Dtos.Client;

public class ClientResponseDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Nif { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Address { get; set; }
}